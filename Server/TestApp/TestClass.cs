using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{

    public struct TestStruct {
        public string  a;
        public string b;
    }

    public class TestClass
    {
        

        Dictionary<int, List<TestStruct>> dic = new Dictionary<int, List<TestStruct>>();


        List<TestStruct> lst1 = new  List<TestStruct>();
        List<TestStruct> lst2 = new  List<TestStruct>();

        public void test()
        {
            for (int i = 0; i < 2; i++)
            {
                List<TestStruct> tlst = new List<TestStruct>();
                for (int j = 0; j < 5; j++)
                {
                    TestStruct t = new TestStruct();
                    t.a = i+"aa"+j;
                    t.b = i+"bb"+j;
                    tlst.Add(t);
                }
                dic.Add(i, tlst);
            }
    

            List<TestStruct> tttts = new List<TestStruct>();

            tttts = dic[0];

            foreach (var item in tttts)
            {
                lst1.Add(item);
            }
            tttts = dic[1];

            foreach (var item in tttts)
            {
                lst2.Add(item);
            }

            Console.ReadKey();
        }
    }
}
