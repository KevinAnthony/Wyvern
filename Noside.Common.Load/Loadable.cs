﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Noside.Common.Load
{
    public abstract class Loadable
    {
		public List<LoadInfo> LoadList { get; } = new List<LoadInfo>();

	    public event EventHandler<NewActionEventArgs> NewAction;

	    protected void OnNewAction(Func<Task> action, string description)
	    {
		    NewAction?.Invoke(this, new NewActionEventArgs(new LoadInfo(action, description)));
	    }

		protected Loadable() {
		    LoadQueue.Register(this);
	    }
    }
}
