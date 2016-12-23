using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace NHibernateTest.Domain
{
    public class acm_penalty_combine_main
    {
        public virtual string cpy_date { get; set; }
        public virtual string water_id { get; set; }
        public virtual string combine_cpy_date { get; set; }
        public virtual string receivable_dept_code { get; set; }
        public virtual string actual_dept_code { get; set; }
        public virtual string recv_date { get; set; }
        public virtual string checkout_date { get; set; }
        public virtual string checkout_user_no { get; set; }
        public virtual string cancel_checkout_date { get; set; }
        public virtual string cancel_checkout_user_no { get; set; }
        public virtual string is_payed { get; set; }
        public virtual string penalty_pay_source { get; set; }
        public virtual string combine_mark { get; set; }
        public virtual string idle_status { get; set; }
        public virtual string idle_date { get; set; }
        public virtual string upd_date { get; set; }
        public virtual string upd_time { get; set; }
        public virtual string upd_user_no { get; set; }
        public virtual int calc_seq { get; set; }
        public virtual int share_seq { get; set; }
        public virtual int combine_calc_seq { get; set; }
        public virtual int combine_share_seq { get; set; }
        public virtual Decimal penalty_amt { get; set; }
        public virtual Byte[] sys_upd_times { get; set; }
    }
}
