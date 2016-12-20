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

namespace NHibernateTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            using (ISession session = MyHibernateHelper.SessionFactory.OpenSession())
            {

                int[] iCondition = { 1, 2 };//條件陣列
                //一般用法
                var result = session.QueryOver<Persons>().Where(x=>x.PersonID==1).List();
                //var result = session.QueryOver<Persons>().List();

               

                //Persons Presult = session.QueryOver<Persons>().List();
                //var result = session.QueryOver<Persons>().Where(x => (x.PersonID >= 1 && x.PersonID <= 2)).List();
                //Like用法
                //var result = session.QueryOver<Persons>().Where(x => x.PersonName.IsLike("測試", MatchMode.Anywhere)).List();
                //in 的用法
                //var result = session.QueryOver<Persons>().Where(x => x.PersonID.IsIn(iCondition)).List();
                //var result = session.QueryOver<Persons>().Where(x=>x.PersonID.IsIn(iCondition)).List();
                //not in 用法
                //var result = session.QueryOver<Persons>().WhereNot(x => x.PersonID.IsIn(iCondition)).List();

                foreach (var item in result)
                {
                    Console.WriteLine("輸出一筆資料：" + item.PersonName);
                }

            }



           // Console.ReadKey();//暫停畫面用


        }
    }
}
