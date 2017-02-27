﻿using ChakraCore.NET.Core.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChakraCore.NET.Core
{
    public class JSValue : ServiceConsumerBase
    {
        public JSValueBinding Binding { get; private set; }
        public JavaScriptValue ReferenceValue { get; private set; }
        public JSValue(IServiceNode parentNode,JavaScriptValue value) : base(parentNode, "JSValue")
        {
            ReferenceValue = value;
            //inject service
            //init binding here
            Binding = new JSValueBinding(ServiceNode,value);

            //add my own one time delegate handler for method/function call
            ServiceNode.PushService<INativeFunctionHolderService>(new NativeFunctionHolderService(true));
        }
    }
}
