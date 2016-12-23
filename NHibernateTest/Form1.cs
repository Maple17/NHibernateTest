using NHibernate;
using NHibernateTest.Domain;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;
using System.Diagnostics;

namespace NHibernateTest
{
    public partial class Form1 : Form
    {
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();
        Stopwatch sw = new Stopwatch();//Stopwatch類別在System.Diagnostics命名空間裡
        long num = 0;
        TimeSpan el;

        public Form1()
        {
            InitializeComponent();                
            
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                using (ISession session = MyHibernateHelper.SessionFactory.OpenSession())
                {

                    int[] iCondition = { 1, 2 };//條件陣列
                    //一般用法
                    //var result = session.QueryOver<Persons>().Where(x=>x.PersonID==1).List();
                    //var result = session.QueryOver<Persons>().List();
                    sw.Reset();
                    sw = Stopwatch.StartNew();

                    logger.Trace("Table Select 之前:");
                    //var result = session.QueryOver<acm_penalty_combine_main>().List();
                    var result = session.QueryOver<Animal>().List();
                    logger.Trace("Table Row Count:" + result.Count);
                    logger.Trace("Table Select 之後:");
                    logger.Trace("Table Select 資料:" + result[0].AnimalID);
                    sw.Stop();
                    el = sw.Elapsed;

                    MessageBox.Show("處理耗時：" + el);

                    //Persons Presult = session.QueryOver<Persons>().List();
                    //var result = session.QueryOver<Persons>().Where(x => (x.PersonID >= 1 && x.PersonID <= 2)).List();
                    //Like用法
                    //var result = session.QueryOver<Persons>().Where(x => x.PersonName.IsLike("測試", MatchMode.Anywhere)).List();
                    //in 的用法
                    //var result = session.QueryOver<Persons>().Where(x => x.PersonID.IsIn(iCondition)).List();
                    //var result = session.QueryOver<Persons>().Where(x=>x.PersonID.IsIn(iCondition)).List();
                    //not in 用法
                    //var result = session.QueryOver<Persons>().WhereNot(x => x.PersonID.IsIn(iCondition)).List();

                    //foreach (var item in result)
                    //{
                    //Console.WriteLine("輸出一筆資料：" + item.PersonName);
                    //}
                    


                }



                // Console.ReadKey();//暫停畫面用
            }

            catch (Exception ex)
            {
                logger.Trace("查詢發生錯誤：" + ex.Message);
            }



        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                sw.Reset();
                sw = Stopwatch.StartNew();

                using (ISession session = MyHibernateHelper.SessionFactory.OpenSession())
                {
                    using (ITransaction trans = session.BeginTransaction())
                    {
                        Persons p = new Persons();
                        
                        p.PersonName = "test";
                        
                        logger.Trace("新增資料開始");
                        object obj = session.Save(p);//如果有設定show_sql為true的話，此句就會印出執行的SQL語句
                        logger.Trace("剛剛新增資料的主鍵:" + obj.ToString());
                        trans.Commit();
                        logger.Trace("新增資料完成");
                        sw.Stop();
                        el = sw.Elapsed;

                        MessageBox.Show("處理耗時：" + el);
                    }//交易失敗會自動Rollback
                }


            }

            catch (Exception ex)
            {
                logger.Trace("新增發生錯誤：" + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                sw.Reset();
                sw = Stopwatch.StartNew();
                using (ISession session = MyHibernateHelper.SessionFactory.OpenSession())
                {
                    using (ITransaction trans = session.BeginTransaction())
                    {
                        //找出DB的資料來Update
                        logger.Trace("修改資料開始");
                        var result = session.QueryOver<Persons>().Where(x => (x.PersonID==1)).List();
                        foreach (var item in result)
                        {
                            item.PersonName = "updated";
                            session.Update(item);//這裡不會輸出SQL
                        }
                        //或建立一個想Update的物件(NHibernate會自行依主鍵找資料Update)
                        //Persons p = new Persons() { PersonID = 1, PersonName = "測試" };
                        //session.Update(p);
                        trans.Commit();//這裡才會真正執行Update
                        logger.Trace("修改資料完成");
                        sw.Stop();
                        el = sw.Elapsed;

                        MessageBox.Show("處理耗時：" + el);
                    }
                }//交易失敗會自動rollback


            }

            catch (Exception ex)
            {
                logger.Trace("修改發生錯誤：" + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                sw.Reset();
                sw = Stopwatch.StartNew();
                using (ISession session = MyHibernateHelper.SessionFactory.OpenSession())
                {
                    using (ITransaction trans = session.BeginTransaction())
                    {
                        //找出DB的資料來Delete
                        logger.Trace("刪除資料開始");
                        var result = session.QueryOver<Persons>().Where(x => (x.PersonID==1)).List();
                        foreach (var item in result)
                        {
                            session.Delete(item);
                        }
                        //或建立一個想Delete的物件(NHibernate會自行依主鍵來Delete)
                        //Persons p = new Persons() { PersonID = 2 };
                        //session.Delete(p);
                        trans.Commit();//和上方的Delete()搭配才會輸出SQL
                        logger.Trace("刪除資料結束");
                        sw.Stop();
                        el = sw.Elapsed;

                        MessageBox.Show("處理耗時：" + el);
                    }//交易失敗會自動Rollback
                }
            }

            catch (Exception ex)
            {
                logger.Trace("刪除發生錯誤：" + ex.Message);
            }
        }
    }
}
