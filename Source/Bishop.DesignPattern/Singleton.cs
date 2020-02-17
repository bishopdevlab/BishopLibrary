// Copyright Bishop(LEE YONG IL). All rights reserved.
// Licensed under the Apache license.
// See LICENSE file in the project root for full license information.

using System;

namespace Bishop.DesignPattern
{
    public class Singleton<T> where T : class
    {
        private static volatile T myInstance;
        private static object myLockObject = new object();

        protected Singleton() { }

        public static T Instance
        {
            get
            {
                if (myInstance == null)
                {
                    lock (myLockObject)
                    {
                        if (myInstance == null)
                        {
                            Type t = typeof(T);
                            myInstance = (T)Activator.CreateInstance(t, true);
                        }
                    }
                }

                return myInstance;
            }
        }
    }
}
