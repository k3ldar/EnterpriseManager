Type.registerNamespace("Sys.Extended.UI.HtmlEditor.ToolbarButtons"),Sys.Extended.UI.HtmlEditor.ToolbarButtons.PasteText=function(t){Sys.Extended.UI.HtmlEditor.ToolbarButtons.PasteText.initializeBase(this,[t])},Sys.Extended.UI.HtmlEditor.ToolbarButtons.PasteText.prototype={callMethod:function(){if(!Sys.Extended.UI.HtmlEditor.ToolbarButtons.PasteText.callBaseMethod(this,"callMethod"))return!1;var t=this._designPanel;if(Sys.Extended.UI.HtmlEditor.isIE)t._saveContent(),t.openWait(),setTimeout(function(){t._paste(!1),t.closeWait()},0);else{var e=t._getSelection(),o=t._createRange(e),s=String.format(Sys.Extended.UI.Resources.HtmlEditor_toolbar_button_Use_verb,Sys.Extended.UI.HtmlEditor.isSafari&&navigator.userAgent.indexOf("mac")!=-1?"Apple-V":"Ctrl-V"),n=String.format(Sys.Extended.UI.Resources.HtmlEditor_toolbar_button_OnPastePlainText,s);alert(n),setTimeout(function(){t._removeAllRanges(e),t._selectRange(e,o)},0),t.isPlainText=!0}}},Sys.Extended.UI.HtmlEditor.ToolbarButtons.PasteText.registerClass("Sys.Extended.UI.HtmlEditor.ToolbarButtons.PasteText",Sys.Extended.UI.HtmlEditor.ToolbarButtons.MethodButton);