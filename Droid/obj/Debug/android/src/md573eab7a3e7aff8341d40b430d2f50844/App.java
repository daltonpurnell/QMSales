package md573eab7a3e7aff8341d40b430d2f50844;


public class App
	extends mono.android.app.Application
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:()V:GetOnCreateHandler\n" +
			"";
	}


	public App () throws java.lang.Throwable
	{
		super ();
	}

	public void onCreate ()
	{
		mono.android.Runtime.register ("QMSales.Droid.App, QMSales.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", App.class, __md_methods);
		n_onCreate ();
	}

	private native void n_onCreate ();

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
