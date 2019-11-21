using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Henry: test test
namespace Study
{
    public class M
    {
        public List<M> list;
        public int value;
        public M(int value)
        {
            this.value = value;
            list = new List<M>();
        }
        public static M Clone(M m)
        {
            if (m.list == null || m.list.Count <= 0)
                return new M(m.value);
            M res = new M(m.value);
            foreach (M item in m.list)
                res.list.Add(M.Clone(item));
            return res;
        }
    }
    public class A
    {
        public List<A> list;
        public int value = 0;

        public M m;
        //M m;
        public A(int value)
        {
            this.value = value;
            list = new List<A>();
            m = new M(value);
        }
        public static A Clone(A a)
        {
            if ((a.list == null || a.list.Count <= 0)
                && (a.m.list == null || a.m.list.Count <= 0))
                return new A(a.value);
            A res = new A(a.value);
            foreach (A item in a.list)
                res.list.Add(A.Clone(item));
            res.m = M.Clone(a.m);
            return res;
        }
    }
    public class Main
    {
        public Main()
        {
            A a = new A(1);

            A a1 = new A(1);
            a1.list.Add(new A(1));
            a.list.Add(a1);

            A a2 = new A(1);

            A a21 = new A(1);
            a21.list.Add(new A(1));

            a2.list.Add(a21);
            a2.list.Add(new A(1));
            a.list.Add(a2);

            //init for M
            M m = new M(1);
            m.list.Add(new M(1));
            a.m.list.Add(m);
            a.m.list.Add(new M(1));

            M m1 = new M(1);
            m.list.Add(new M(1));
            a1.m.list.Add(m1);
            a1.m.list.Add(new M(1));

            a21.m.list.Add(new M(1));
            //assign
            A b = A.Clone(a);
            //change value
            b.list[1].value = 2;
            b.list[1].list[0].m.value = 7;

            int n = 1;
        }
    }
}
