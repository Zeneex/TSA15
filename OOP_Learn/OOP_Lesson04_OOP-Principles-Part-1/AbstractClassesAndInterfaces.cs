using System;

namespace SomeNameSpace
{
    public abstract class AbstractClass
    {
        private int instanceInt;
        public static int staticInt;
        /*private abstract int instanceAbstractInt;*/
        /*private static abstract int staticAbstractInt;*/

        public AbstractClass() { }                          //instance constructor
        /*public*/ static AbstractClass() { }               //static constructor (for the static members)
        public /*abstract*/ AbstractClass(object obj) { }   //instance abstract constructor
        /*public static abstract ThirdAbstractClass();*/    //static abstract constructor

        public int InstanceProperty { get; set; }
        public static int StaticProperty { get; set; }
        public abstract int InstanceAbstractProperty { get; set; }
        /*public static abstract int StaicAbstractProperty { get; set; }*/

        public void InstanceVoidMehtod() { }
        public static void StaticVoidMethod() { }
        public abstract void InstanceAbstractVoidMethod();
        /*public static abstract void StaticAbstractVoidMethod();*/
    }

    public interface IInterface
    {
        /*
        private int instanceInt;
        private static int staticInt;
        private abstract int instanceAbstractInt;
        private static abstract int staticAbstractInt;
        private static const int staticConstant = 5;
        private static readonly int staticReadonly;
         */

        /*
        public IInterface();                            //instance constructor
        public static IInterface();                     //static constructor (for the static members)
        public abstract IInterface(int integer);        //instance abstract constructor
        public static abstract IInterface(int integer); //static abstract constructor
         */

        /*public*/ int InstanceProperty { get; set; }
        /*public*/ /*static*/ int StaticProperty { get; set; }
        /*public*/ /*abstract*/ int InstanceAbstractProperty { get; set; }
        /*public*/ /*static*/ /*abstract*/ int StaicAbstractProperty { get; set; }

        /*public*/ void InstanceVoidMehtod();
        /*public*/ /*static*/ void StaticVoidMethod();
        /*public*/ /*abstract*/ void InstanceAbstractVoidMethod();
        /*public*/ /*static*/ /*abstract*/ void StaticAbstractVoidMethod();

        /*public void InstanceVoidMethod_Implemented() { }*/
    }
}