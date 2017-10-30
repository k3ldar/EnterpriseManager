using System;

namespace Website.Library.Classes
{
	/// <summary>
	/// Event interface for posts
	/// </summary>
	public delegate void EventNotify(object sender);

    public delegate void WizardNextPageDelegate(object sender, NextPageArgs e);

    public class NextPageArgs : EventArgs
    {
        public NextPageArgs(int page) { Page = page; }

        public int Page { private set; get; }
    }
}
