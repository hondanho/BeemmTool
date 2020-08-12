using BEEMTOOL;
using BEEMTOOL.BEMMTOOL;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BEMMTOOL.My
{
    internal sealed class MyProject
    {
        [MyGroupCollection("System.Windows.Forms.Form", "Create__Instance__", "Dispose__Instance__", "My.MyProject.Forms")]
        internal sealed class MyForms
        {

            [ThreadStatic]
            private static Hashtable m_FormBeingCreated;
            public AboutMe m_AboutMe;
            public DONATE m_DONATE;
            public gialap m_gialap;
            public loading m_loading;
            public naptienvaomay m_naptienvaomay;
            public thietlapkeyrentcode m_thietlapkeyrentcode;
            public thongbao m_thongbao;
            public thongbao2 m_thongbao2;
            public thongbao3 m_thongbao3;
            public thongbaochinh m_thongbaochinh;
            public trangchu m_trangchu;
            public AboutMe AboutMe
            {
                get
                {
                    m_AboutMe = Create__Instance__(m_AboutMe);
                    return m_AboutMe;
                }
                set
                {
                    if (value != m_AboutMe)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_AboutMe);
                    }
                }
            }

            public DONATE DONATE
            {
                get
                {
                    m_DONATE = Create__Instance__(m_DONATE);
                    return m_DONATE;
                }
                set
                {
                    if (value != m_DONATE)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_DONATE);
                    }
                }
            }

            public gialap gialap
            {
                get
                {
                    m_gialap = Create__Instance__(m_gialap);
                    return m_gialap;
                }
                set
                {
                    if (value != m_gialap)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_gialap);
                    }
                }
            }

            public loading loading
            {
                get
                {
                    m_loading = Create__Instance__(m_loading);
                    return m_loading;
                }
                set
                {
                    if (value != m_loading)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_loading);
                    }
                }
            }

            public naptienvaomay naptienvaomay
            {
                get
                {
                    m_naptienvaomay = Create__Instance__(m_naptienvaomay);
                    return m_naptienvaomay;
                }
                set
                {
                    if (value != m_naptienvaomay)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_naptienvaomay);
                    }
                }
            }

            public thietlapkeyrentcode thietlapkeyrentcode
            {
                get
                {
                    m_thietlapkeyrentcode = Create__Instance__(m_thietlapkeyrentcode);
                    return m_thietlapkeyrentcode;
                }
                set
                {
                    if (value != m_thietlapkeyrentcode)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_thietlapkeyrentcode);
                    }
                }
            }

            public thongbao thongbao
            {
                get
                {
                    m_thongbao = Create__Instance__(m_thongbao);
                    return m_thongbao;
                }
                set
                {
                    if (value != m_thongbao)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_thongbao);
                    }
                }
            }

            public thongbao2 thongbao2
            {
                get
                {
                    m_thongbao2 = Create__Instance__(m_thongbao2);
                    return m_thongbao2;
                }
                set
                {
                    if (value != m_thongbao2)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_thongbao2);
                    }
                }
            }

            public thongbao3 thongbao3
            {
                get
                {
                    m_thongbao3 = Create__Instance__(m_thongbao3);
                    return m_thongbao3;
                }
                set
                {
                    if (value != m_thongbao3)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_thongbao3);
                    }
                }
            }

            public thongbaochinh thongbaochinh
            {
                get
                {
                    m_thongbaochinh = Create__Instance__(m_thongbaochinh);
                    return m_thongbaochinh;
                }
                set
                {
                    if (value != m_thongbaochinh)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_thongbaochinh);
                    }
                }
            }

            public trangchu trangchu
            {
                get
                {
                    m_trangchu = Create__Instance__(m_trangchu);
                    return m_trangchu;
                }
                set
                {
                    if (value != m_trangchu)
                    {
                        if (value != null)
                        {
                            throw new ArgumentException("Property can only be set to Nothing");
                        }
                        Dispose__Instance__(ref m_trangchu);
                    }
                }
            }

            private static T Create__Instance__<T>(T Instance) where T : Form, new()
            {
                if (Instance?.IsDisposed ?? true)
                {
                    if (m_FormBeingCreated != null)
                    {
                        if (m_FormBeingCreated.ContainsKey(typeof(T)))
                        {
                            throw new InvalidOperationException(Utils.GetResourceString("WinForms_RecursiveFormCreate"));
                        }
                    }
                    else
                    {
                        m_FormBeingCreated = new Hashtable();
                    }
                    m_FormBeingCreated.Add(typeof(T), null);
                    var ex2 = new Exception();
                    try
                    {
                        return new T();
                    }
                    catch (TargetInvocationException ex) when (((Func<bool>)delegate
                    {
                        // Could not convert BlockContainer to single expression
                        ProjectData.SetProjectError(ex);
                        ex2 = ex;
                        return ex2.InnerException != null;
                    }).Invoke())
                    {
                        string resourceString = Utils.GetResourceString("WinForms_SeeInnerException", ex2.InnerException.Message);
                        throw new InvalidOperationException(resourceString, ex2.InnerException);
                    }
                    finally
                    {
                        m_FormBeingCreated.Remove(typeof(T));
                    }
                }
                return Instance;
            }

            private void Dispose__Instance__<T>(ref T instance) where T : Form
            {
                instance.Dispose();
                instance = null;
            }

            public MyForms()
            {
            }

            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            internal new Type GetType()
            {
                return typeof(MyForms);
            }

            public override string ToString()
            {
                return base.ToString();
            }
        }

        [MyGroupCollection("System.Web.Services.Protocols.SoapHttpClientProtocol", "Create__Instance__", "Dispose__Instance__", "")]
        internal sealed class MyWebServices
        {
            public override bool Equals(object o)
            {
                return base.Equals(RuntimeHelpers.GetObjectValue(o));
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }

            internal new Type GetType()
            {
                return typeof(MyWebServices);
            }

            public override string ToString()
            {
                return base.ToString();
            }

            private static T Create__Instance__<T>(T instance) where T : new()
            {
                if (instance == null)
                {
                    return new T();
                }
                return instance;
            }

            private void Dispose__Instance__<T>(ref T instance)
            {
                instance = default(T);
            }

            public MyWebServices()
            {
            }
        }

        [ComVisible(false)]
        internal sealed class ThreadSafeObjectProvider<T> where T : new()
        {
            private static T m_ThreadStaticValue;
            internal T GetInstance
            {
                get
                {
                    if (m_ThreadStaticValue == null)
                    {
                        m_ThreadStaticValue = new T();
                    }
                    return m_ThreadStaticValue;
                }
            }

            public ThreadSafeObjectProvider()
            {
            }
        }

        private static readonly ThreadSafeObjectProvider<MyComputer> m_ComputerObjectProvider = new ThreadSafeObjectProvider<MyComputer>();

        private static readonly ThreadSafeObjectProvider<MyApplication> m_AppObjectProvider = new ThreadSafeObjectProvider<MyApplication>();

        private static readonly ThreadSafeObjectProvider<User> m_UserObjectProvider = new ThreadSafeObjectProvider<User>();

        private static ThreadSafeObjectProvider<MyForms> m_MyFormsObjectProvider = new ThreadSafeObjectProvider<MyForms>();

        private static readonly ThreadSafeObjectProvider<MyWebServices> m_MyWebServicesObjectProvider = new ThreadSafeObjectProvider<MyWebServices>();

        [HelpKeyword("My.Computer")]
        internal static MyComputer Computer
        {
            get
            {
                return m_ComputerObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Application")]
        internal static MyApplication Application
        {
            get
            {
                return m_AppObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.User")]
        internal static User User
        {
            get
            {
                return m_UserObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.Forms")]
        internal static MyForms Forms
        {
            get
            {
                return m_MyFormsObjectProvider.GetInstance;
            }
        }

        [HelpKeyword("My.WebServices")]
        internal static MyWebServices WebServices
        {
            get
            {
                return m_MyWebServicesObjectProvider.GetInstance;
            }
        }

        internal sealed class MySettingsProperty
        {
            [System.ComponentModel.Design.HelpKeyword("My.Settings")]
            internal static MySettings Settings => MySettings.Default;
        }
    }
}
