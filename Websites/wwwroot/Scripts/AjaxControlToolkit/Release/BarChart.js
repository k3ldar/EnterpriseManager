Type.registerNamespace("Sys.Extended.UI"),Sys.Extended.UI.BarChart=function(t){Sys.Extended.UI.BarChart.initializeBase(this,[t]),this._chartWidth="300",this._chartHeight="200",this._chartTitle="",this._categoriesAxis="",this._series=null,this._chartType=Sys.Extended.UI.BarChartType.Column,this._theme="BarChart",this._valueAxisLines=9,this._chartTitleColor="",this._valueAxisLineColor="",this._categoryAxisLineColor="",this._baseLineColor="",this._container=null,this.yMax=0,this.yMin=0,this.xMax=0,this.xMin=0,this.roundedTickRange=0,this.startX=0,this.startY=0,this.endX=0,this.endY=0,this.xInterval=0,this.yInterval=0,this.arrXAxis,this.arrXAxisLength=0,this.arrYAxis,this.arrYAxisLength=0,this.charLength=3.5,this.arrCombinedData=null},Sys.Extended.UI.BarChart.prototype={initialize:function(){if(Sys.Extended.UI.BarChart.callBaseMethod(this,"initialize"),!document.implementation.hasFeature("http://www.w3.org/TR/SVG11/feature#Image","1.1"))throw"Browser does not support SVG.";0==this._valueAxisLines&&(this._valueAxisLines=9),this._parentDiv=this.get_container(),this._chartType==Sys.Extended.UI.BarChartType.Column||this._chartType==Sys.Extended.UI.BarChartType.StackedColumn?this.generateColumnChart():this._chartType!=Sys.Extended.UI.BarChartType.Bar&&this._chartType!=Sys.Extended.UI.BarChartType.StackedBar||this.generateBarChart()},dispose:function(){Sys.Extended.UI.BarChart.callBaseMethod(this,"dispose")},generateColumnChart:function(){this.arrXAxis=this._categoriesAxis.split(","),this.arrXAxisLength=this.arrXAxis.length,this.calculateMinMaxValuesForColumnType(),this.calculateIntervalForColumnType(),this.calculateValueAxisForColumnType();var t=this.initializeSVG();t+=String.format('<text x="{0}" y="{1}" id="ChartTitle" style="fill:{3}">{2}</text>',parseInt(this._chartWidth)/2-this._chartTitle.length*this.charLength,5*parseInt(this._chartHeight)/100,this._chartTitle,this._chartTitleColor),t+=this.drawBackgroundHorizontalLinesForColumnType(),t+=this.drawBackgroundVerticalLinesForColumnType(),t+=this.drawBaseLinesForColumnType(),t+=this.drawLegendArea(),t+=this.drawAxisValuesForColumnType(),t+=this.drawBarsForColumnType(),t+="</svg>",this._parentDiv.innerHTML=t},calculateIntervalForColumnType:function(){this.startX=10*this._chartWidth/100+.5,this.endX=parseInt(this._chartWidth)-4.5,this.yMin>=0?this.startY=Math.round(parseInt(this._chartHeight)-24*parseInt(this._chartHeight)/100)+.5:this.startY=Math.round(parseInt(this._chartHeight)-12*parseInt(this._chartHeight)/100)/2+.5,this.yInterval=this.startY/(this._valueAxisLines+1)},calculateMinMaxValuesForColumnType:function(t){var i,s,r;if(this._chartType==Sys.Extended.UI.BarChartType.Column)for(var e=0;e<this._series.length;e++)r=this._series[e].Data,i=Math.max.apply(null,r),s=Math.min.apply(null,r),0==e?(this.yMax=i,this.yMin=s):(i>this.yMax&&(this.yMax=i),s<this.yMin&&(this.yMin=s));else{this.arrCombinedData=null;for(var e=0;e<this._series.length;e++){r=new Array;for(var a=0;a<this._series[e].Data.length;a++)r[a]=this._series[e].Data[a];if(null==this.arrCombinedData)this.arrCombinedData=r;else for(var a=0;a<r.length;a++)this.arrCombinedData[a]=parseFloat(this.arrCombinedData[a])+parseFloat(r[a])}for(var e=0;e<this._series.length;e++)s=Math.min.apply(null,this._series[e].Data),0==e?this.yMin=s:s<this.yMin&&(this.yMin=s);this.yMax=Math.max.apply(null,this.arrCombinedData)}this.yMin<0&&(this._valueAxisLines=Math.round(this._valueAxisLines/2))},calculateValueAxisForColumnType:function(){var t,i,s,r;t=this.yMin>=0?this.yMax:this.yMax>Math.abs(this.yMin)?this.yMax:Math.abs(this.yMin),i=t/(this._valueAxisLines-1),i<1?this.roundedTickRange=i.toFixed(1):(s=Math.ceil(Math.log(i)/Math.log(10)-1),r=Math.pow(10,s),this.roundedTickRange=Math.ceil(i/r)*r),this.startX=this.startX+(10*this.roundedTickRange*this._valueAxisLines/10).toString().length*this.charLength},drawBackgroundHorizontalLinesForColumnType:function(){for(var t="",i=1;i<=this._valueAxisLines;i++)t+=String.format('<path d="M{0} {2} {1} {2}" id="HorizontalLine" style="stroke:{3}"></path>',this.startX,this.endX,this.startY-this.yInterval*i,this._categoryAxisLineColor);if(this.yMin<0)for(var i=1;i<=this._valueAxisLines;i++)t+=String.format('<path d="M{0} {2} {1} {2}" id="HorizontalLine" style="stroke:{3}"></path>',this.startX,this.endX,this.startY+this.yInterval*i,this._categoryAxisLineColor);return t},drawBackgroundVerticalLinesForColumnType:function(){var t="";this.xInterval=Math.round((parseInt(this._chartWidth)-this.startX)/this.arrXAxisLength);for(var i=0;i<this.arrXAxisLength;i++)t+=String.format('<path id="VerticalLine" d="M{0} {1} {0} {2}" style="stroke:{3}"></path>',parseInt(this._chartWidth)-5-this.xInterval*i,this.startY-this.yInterval*this._valueAxisLines,this.startY,this._valueAxisLineColor);if(this.yMin<0)for(var i=0;i<this.arrXAxisLength;i++)t+=String.format('<path id="VerticalLine" d="M{0} {1} {0} {2}" style="stroke:{3}"></path>',parseInt(this._chartWidth)-5-this.xInterval*i,this.startY+this.yInterval*this._valueAxisLines,this.startY,this._valueAxisLineColor);return t},drawBaseLinesForColumnType:function(){var t="";t+=String.format('<path d="M{0} {1} {2} {1}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.startY,this.endX,this._baseLineColor),t+=String.format('<path d="M{0} {1} {0} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.startY-this.yInterval*this._valueAxisLines,this.startY,this._baseLineColor),t+=String.format('<path d="M{0} {1} {0} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.startY,this.startY+4,this._baseLineColor);for(var i=0;i<this.arrXAxisLength;i++)t+=String.format('<path d="M{0} {1} {0} {2}" id="BaseLine" style="stroke:{3}"></path>',parseInt(this._chartWidth)-5-this.xInterval*i,this.startY,this.startY+4,this._baseLineColor);for(var i=0;i<=this._valueAxisLines;i++)t+=String.format('<path d="M{0} {2} {1} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX-4,this.startX,this.startY-this.yInterval*i,this._baseLineColor);if(this.yMin<0){t+=String.format('<path d="M{0} {1} {0} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.startY+this.yInterval*this._valueAxisLines,this.startY,this._baseLineColor);for(var i=1;i<=this._valueAxisLines;i++)t+=String.format('<path d="M{0} {2} {1} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX-4,this.startX,this.startY+this.yInterval*i,this._baseLineColor)}return t},drawAxisValuesForColumnType:function(){for(var t="",i=0,s=0;s<this.arrXAxisLength;s++)i=5.5*this.arrXAxis[s].toString().length,t+=String.format('<text id="SeriesAxis" x="{0}" y="{1}" fill-opacity="1">{2}</text>',Math.round(this.startX+10*this.xInterval*s/10+50*this.xInterval/100-i),this.startY+Math.round(65*this.yInterval/100),this.arrXAxis[s]);for(var s=0;s<=this._valueAxisLines;s++)i=5.5*(10*this.roundedTickRange*s/10).toString().length,t+=String.format('<text id="ValueAxis" x="{0}" y="{1}">{2}</text>',this.startX-i-15,this.startY-10*this.yInterval*s/10+3.5,10*this.roundedTickRange*s/10);if(this.yMin<0)for(var s=1;s<=this._valueAxisLines;s++)i=5.5*(10*this.roundedTickRange*s/10).toString().length,t+=String.format('<text id="ValueAxis" x="{0}" y="{1}">-{2}</text>',this.startX-i-19,this.startY+10*this.yInterval*s/10,10*this.roundedTickRange*s/10);return t},drawBarsForColumnType:function(){var t,i="",s=this._series.length,r=10*this.xInterval/100;t=this._chartType==Sys.Extended.UI.BarChartType.Column?Math.round((80*this.xInterval/100-r*s)/s):Math.round(80*this.xInterval/100);for(var e=0;e<this.arrXAxisLength;e++){if(i+="<g>",this._chartType==Sys.Extended.UI.BarChartType.Column)for(var a=0;a<this._series.length;a++)this.yVal=parseFloat(this._series[a].Data[e]),i+=0==e?String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',this.startX+this.xInterval*e+15*this.xInterval/100+(r+t)*a,this.startX+this.xInterval*e+15*this.xInterval/100+(r+t)*a+t,this.startY,this.startY-Math.round(this.yVal*(this.yInterval/this.roundedTickRange)),a+1,this._series[a].BarColor):String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',this.startX+this.xInterval*e+12.5*this.xInterval/100+(r+t)*a,this.startX+this.xInterval*e+12.5*this.xInterval/100+(r+t)*a+t,this.startY,this.startY-Math.round(this.yVal*(this.yInterval/this.roundedTickRange)),a+1,this._series[a].BarColor),i+=this.yVal>0?String.format('<text id="LegendText" x="{0}" y="{1}">{2}</text>',this.startX+this.xInterval*e+20*this.xInterval/100+(r+t)*a+10*t/100-Math.round(this.yVal.toString().length*this.charLength/2),this.startY-Math.round(this.yVal*(this.yInterval/this.roundedTickRange))-7.5,this.yVal):String.format('<text id="LegendText" x="{0}" y="{1}">{2}</text>',this.startX+this.xInterval*e+20*this.xInterval/100+(r+t)*a+10*t/100-Math.round(this.yVal.toString().length*this.charLength/2),this.startY-Math.round(this.yVal*(this.yInterval/this.roundedTickRange))+7.5,this.yVal);else for(var h=this.startY,n=this.startY,a=0;a<this._series.length;a++)this.yVal=parseFloat(this._series[a].Data[e]),i+=0==e?this.yVal>0?String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',this.startX+10*this.xInterval*e/10+7.5*this.xInterval/100,this.startX+10*this.xInterval*e/10+7.5*this.xInterval/100+t,h,h-Math.round(this.yVal*(this.yInterval/this.roundedTickRange)),a+1,this._series[a].BarColor):String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',this.startX+10*this.xInterval*e/10+7.5*this.xInterval/100,this.startX+10*this.xInterval*e/10+7.5*this.xInterval/100+t,n,n-Math.round(this.yVal*(this.yInterval/this.roundedTickRange)),a+1,this._series[a].BarColor):this.yVal>0?String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',this.startX+10*this.xInterval*e/10+5*this.xInterval/100,this.startX+10*this.xInterval*e/10+5*this.xInterval/100+t,h,h-Math.round(this.yVal*(this.yInterval/this.roundedTickRange)),a+1,this._series[a].BarColor):String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',this.startX+10*this.xInterval*e/10+5*this.xInterval/100,this.startX+10*this.xInterval*e/10+5*this.xInterval/100+t,n,n-Math.round(this.yVal*(this.yInterval/this.roundedTickRange)),a+1,this._series[a].BarColor),this.yVal>0?(i+=String.format('<text id="LegendText" x="{0}" y="{1}">{2}</text>',this.startX+10*this.xInterval*e/10+30*this.xInterval/100+10*t/100,h-Math.round(this.yVal*(this.yInterval/this.roundedTickRange)/2),this.yVal),h-=Math.round(this.yVal*(this.yInterval/this.roundedTickRange))):(i+=String.format('<text id="LegendText" x="{0}" y="{1}">{2}</text>',this.startX+10*this.xInterval*e/10+30*this.xInterval/100+10*t/100,n+Math.round(Math.abs(this.yVal)*(this.yInterval/this.roundedTickRange)/2),this.yVal),n-=Math.round(this.yVal*(this.yInterval/this.roundedTickRange)));i+="</g>"}return i},initializeSVG:function(){var t=String.format('<?xml-stylesheet type="text/css" href="{0}.css"?>',this._theme);return t+=String.format('<svg xmlns="http://www.w3.org/2000/svg" version="1.1" width="{0}" height="{1}" style="position: relative; display: block;">',this._chartWidth,this._chartHeight),t+="<defs>",t+='<linearGradient gradientTransform="rotate(0)">',t+='<stop offset="0%" id="LinearGradient1"></stop>',t+='<stop offset="25%" id="LinearGradient2"></stop>',t+='<stop offset="100%" id="LinearGradient3"></stop></linearGradient>',t+="</defs>",t+=String.format('<rect id="ChartBackGround" width="{0}" height="{1}" style="opacity: 0"/>',this._chartWidth,this._chartHeight)},drawLegendArea:function(){for(var t="",i=84*parseInt(this._chartHeight)/100+5,s=7.5,r=7.5,e=5,a=0,h=0;h<this._series.length;h++)a+=this._series[h].Name.length;var n=Math.round(5*a/2)+Math.round((s+2*e)*this._series.length),l=!1;n>parseInt(this._chartWidth)/2&&(n/=2,l=!0),t+="<g>",t+=String.format('<path d="M{0} {1} {2} {1} {2} {3} {0} {3} z" id="LegendArea" stroke=""></path>',Math.round(parseInt(this._chartWidth)/2-n/2),i,Math.round(parseInt(this._chartWidth)/2+n/2),Math.round(97.5*parseInt(this._chartHeight)/100));for(var o=40*parseInt(this._chartWidth)/100-n/2+s+e,d=o,x=40*parseInt(this._chartWidth)/100-n/2,u=x,h=0;h<this._series.length;h++)l&&h==Math.round(this._series.length/2)&&(o=40*parseInt(this._chartWidth)/100-n/2+s+e,d=o,x=40*parseInt(this._chartWidth)/100-n/2,u=x,i=91*parseInt(this._chartHeight)/100+5,l=!1),x=u,o=d,t+=String.format('<path d="M{0} {1} {2} {1} {2} {3} {0} {3} z" id="Legend{4}" style="fill:{5}"></path>',x,i+r,x+s,i+15,h+1,this._series[h].BarColor),t+=String.format('<text x="{0}" y="{1}" id="LegendText">{2}</text>',o,i+15,this._series[h].Name),this._series[h].Name.length>10?(u=x+5*this._series[h].Name.length+s+2*e,d=o+5*this._series[h].Name.length+s+2*e):(u=u+6*this._series[h].Name.length+s+2*e,d=d+6*this._series[h].Name.length+s+2*e);return t+="</g>"},generateBarChart:function(){this.arrYAxis=this._categoriesAxis.split(","),this.arrYAxisLength=this.arrYAxis.length,this.calculateMinMaxValuesForBarType(),this.calculateIntervalForBarType(),this.calculateValueAxisForBarType();var t=this.initializeSVG();t+=String.format('<text x="{0}" y="{1}" id="ChartTitle" style="fill:{3}">{2}</text>',parseInt(this._chartWidth)/2-this._chartTitle.length*this.charLength,5*parseInt(this._chartHeight)/100,this._chartTitle,this._chartTitleColor),t+=this.drawBackgroundHorizontalLinesForBarType(),t+=this.drawBackgroundVerticalLinesForBarType(),t+=this.drawBaseLinesForBarType(),t+=this.drawLegendArea(),t+=this.drawAxisValuesForBarType(),t+=this.drawBarsForBarType(),t+="</svg>",this._parentDiv.innerHTML=t},calculateIntervalForBarType:function(){this.startY=Math.round(parseInt(this._chartHeight)-20*parseInt(this._chartHeight)/100)+.5,this.endY=8*parseInt(this._chartHeight)/100+5,this.endX=parseInt(this._chartWidth)-10+.5,this.xMin>=0?this.startX=15*this._chartWidth/100+.5:this.startX=Math.round(parseInt(this._chartWidth)/2)+.5,this.xInterval=Math.round((this.endX-this.startX)/this._valueAxisLines)},calculateMinMaxValuesForBarType:function(t){var i,s,r;if(this._chartType==Sys.Extended.UI.BarChartType.Bar)for(var e=0;e<this._series.length;e++)r=this._series[e].Data,i=Math.max.apply(null,r),s=Math.min.apply(null,r),0==e?(this.xMax=i,this.xMin=s):(i>this.xMax&&(this.xMax=i),s<this.yMin&&(this.xMin=s));else{this.arrCombinedData=null;for(var e=0;e<this._series.length;e++){r=new Array;for(var a=0;a<this._series[e].Data.length;a++)r[a]=this._series[e].Data[a];if(null==this.arrCombinedData)this.arrCombinedData=r;else for(a=0;a<r.length;a++)this.arrCombinedData[a]=parseFloat(this.arrCombinedData[a])+parseFloat(r[a])}for(var e=0;e<this._series.length;e++)s=Math.min.apply(null,this._series[e].Data),0==e?this.xMin=s:s<this.xMin&&(this.xMin=s);this.xMax=Math.max.apply(null,this.arrCombinedData)}this.xMin<0&&(this._valueAxisLines=Math.round(this._valueAxisLines/2))},calculateValueAxisForBarType:function(){var t,i,s,r;t=this.xMin>=0?this.xMax:this.xMax>Math.abs(this.xMin)?this.xMax:Math.abs(this.xMin),i=t/(this._valueAxisLines-1),i<1?this.roundedTickRange=i.toFixed(1):(s=Math.ceil(Math.log(i)/Math.log(10)-1),r=Math.pow(10,s),this.roundedTickRange=Math.ceil(i/r)*r)},drawBackgroundVerticalLinesForBarType:function(){for(var t="",i=1;i<=this._valueAxisLines;i++)t+=String.format('<path id="VerticalLine" d="M{0} {1} {0} {2}" style="stroke:{3}"></path>',this.startX+this.xInterval*i,this.startY,this.startY-this.yInterval*this.arrYAxisLength,this._categoryAxisLineColor);if(this.xMin<0)for(var i=1;i<=this._valueAxisLines;i++)t+=String.format('<path id="VerticalLine" d="M{0} {1} {0} {2}" style="stroke:{3}"></path>',this.startX-this.xInterval*i,this.startY,this.startY-this.yInterval*this.arrYAxisLength,this._categoryAxisLineColor);return t},drawBackgroundHorizontalLinesForBarType:function(){var t="";this.yInterval=Math.round((this.startY-this.endY)/this.arrYAxisLength);for(var i=0;i<=this.arrYAxisLength;i++)t+=String.format('<path id="HorizontalLine" d="M{0} {2} {1} {2}" style="stroke:{3}"></path>',this.startX,this.startX+this.xInterval*this._valueAxisLines,this.startY-this.yInterval*i,this._valueAxisLineColor);if(this.xMin<0)for(var i=0;i<=this.arrYAxisLength;i++)t+=String.format('<path id="HorizontalLine" d="M{0} {2} {1} {2}" style="stroke:{3}"></path>',this.startX,this.startX-this.xInterval*this._valueAxisLines,this.startY-this.yInterval*i,this._valueAxisLineColor);return t},drawBaseLinesForBarType:function(){var t="";t+=String.format('<path d="M{0} {1} {0} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.startY,this.endY,this._baseLineColor),t+=String.format('<path d="M{0} {2} {1} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.startX-4,this.startY,this._baseLineColor),t+=String.format('<path d="M{0} {2} {1} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.endX,this.startY,this._baseLineColor);for(var i=0;i<this.arrYAxisLength;i++)t+=String.format('<path d="M{0} {2} {1} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.startX-4,this.startY-this.yInterval*i,this._baseLineColor);for(var i=0;i<=this._valueAxisLines;i++)t+=String.format('<path d="M{0} {1} {0} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX+this.xInterval*i,this.startY,this.startY+4,this._baseLineColor);if(this.xMin<0){t+=String.format('<path d="M{0} {2} {1} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX,this.startX-this.xInterval*this._valueAxisLines,this.startY,this._baseLineColor);for(var i=1;i<=this._valueAxisLines;i++)t+=String.format('<path d="M{0} {1} {0} {2}" id="BaseLine" style="stroke:{3}"></path>',this.startX-this.xInterval*i,this.startY,this.startY+4,this._baseLineColor)}return t},drawAxisValuesForBarType:function(){for(var t="",i=0,s=0;s<this.arrYAxisLength;s++)i=6.5*this.arrYAxis[s].toString().length,t+=String.format('<text id="SeriesAxis" x="{0}" y="{1}">{2}</text>',this.startX-15*this.xInterval/100-i,Math.round(this.startY-this.yInterval*(s+1)+60*this.yInterval/100),this.arrYAxis[s]);for(var s=0;s<=this._valueAxisLines;s++)t+=String.format('<text id="ValueAxis" x="{0}" y="{1}">{2}</text>',this.startX+this.xInterval*s-(this.roundedTickRange*s).toString().length*this.charLength,this.startY+35*this.yInterval/100,this.roundedTickRange*s);if(this.xMin<0)for(var s=1;s<=this._valueAxisLines;s++)t+=String.format('<text id="ValueAxis" x="{0}" y="{1}">-{2}</text>',this.startX-this.xInterval*s-(this.roundedTickRange*s).toString().length*this.charLength,this.startY+35*this.yInterval/100,this.roundedTickRange*s);return t},drawBarsForBarType:function(){for(var t="",i=this._series.length,s=10*this.yInterval/100,r=this._chartType==Sys.Extended.UI.BarChartType.Bar?Math.round((80*this.yInterval/100-s*i)/i):Math.round(80*this.yInterval/100),e=0;e<this.arrYAxisLength;e++){if(t+="<g>",this._chartType==Sys.Extended.UI.BarChartType.Bar)for(var a=0;a<this._series.length;a++)this.xVal=this._series[a].Data[e],t+=0==e?String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',this.startX,this.startX+Math.round(this.xVal*(this.xInterval/this.roundedTickRange)),this.startY-this.yInterval*e-15*this.yInterval/100-(s+r)*a,this.startY-this.yInterval*e-15*this.yInterval/100-(s+r)*a-r,a+1,this._series[a].BarColor):String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',this.startX,this.startX+Math.round(this.xVal*(this.xInterval/this.roundedTickRange)),this.startY-this.yInterval*e-12.5*this.yInterval/100-(s+r)*a,this.startY-this.yInterval*e-12.5*this.yInterval/100-(s+r)*a-r,a+1,this._series[a].BarColor),t+=this.xVal>0?String.format('<text id="LegendText" x="{0}" y="{1}">{2}</text>',this.startX+Math.round(this.xVal*(this.xInterval/this.roundedTickRange))+this.xVal.toString().length*this.charLength,this.startY-this.yInterval*e-20*this.yInterval/100-(s+r)*a-10*r/100,this.xVal):String.format('<text id="LegendText" x="{0}" y="{1}">{2}</text>',this.startX+Math.round(this.xVal*(this.xInterval/this.roundedTickRange))-(this.xVal.toString().length+1)*this.charLength-5,this.startY-this.yInterval*e-20*this.yInterval/100-(s+r)*a-10*r/100,this.xVal);else for(var h=this.startX,n=this.startX,a=0;a<this._series.length;a++)this.xVal=this._series[a].Data[e],t+=0==e?this.xVal>0?String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',h,h+Math.round(this.xVal*(this.xInterval/this.roundedTickRange)),this.startY-this.yInterval*e-10*this.yInterval/100,this.startY-this.yInterval*e-10*this.xInterval/100-r,a+1,this._series[a].BarColor):String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',n,n+Math.round(this.xVal*(this.xInterval/this.roundedTickRange)),this.startY-this.yInterval*e-10*this.yInterval/100,this.startY-this.yInterval*e-10*this.xInterval/100-r,a+1,this._series[a].BarColor):this.xVal>0?String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',h,h+Math.round(this.xVal*(this.xInterval/this.roundedTickRange)),this.startY-this.yInterval*e-7.55*this.yInterval/100,this.startY-this.yInterval*e-7.5*this.xInterval/100-r,a+1,this._series[a].BarColor):String.format('<path id="Bar{4}" style="fill:{5}" d="M{0} {2} {1} {2} {1} {3} {0} {3} z" />',n,n+Math.round(this.xVal*(this.xInterval/this.roundedTickRange)),this.startY-this.yInterval*e-7.55*this.yInterval/100,this.startY-this.yInterval*e-7.5*this.xInterval/100-r,a+1,this._series[a].BarColor),this.xVal>0?(t+=String.format('<text id="LegendText" x="{0}" y="{1}">{2}</text>',h+Math.round(this.xVal*(this.xInterval/this.roundedTickRange)/2),this.startY-this.yInterval*e-30*this.yInterval/100-10*r/100,this.xVal),h+=Math.round(this.xVal*(this.xInterval/this.roundedTickRange))):(t+=String.format('<text id="LegendText" x="{0}" y="{1}">{2}</text>',n+Math.round(this.xVal*(this.xInterval/this.roundedTickRange)/2),this.startY-this.yInterval*e-30*this.yInterval/100-10*r/100,this.xVal),n+=Math.round(this.xVal*(this.xInterval/this.roundedTickRange)));t+="</g>"}return t},get_chartWidth:function(){return this._chartWidth},set_chartWidth:function(t){this._chartWidth=t},get_chartHeight:function(){return this._chartHeight},set_chartHeight:function(t){this._chartHeight=t},get_chartTitle:function(){return this._chartTitle},set_chartTitle:function(t){this._chartTitle=t},get_categoriesAxis:function(){return this._categoriesAxis},set_categoriesAxis:function(t){this._categoriesAxis=t},get_clientSeries:function(){return this._series},set_clientSeries:function(t){this._series=t},get_ClientSeries:function(){return Sys.Extended.Deprecated("get_ClientSeries","get_clientSeries"),this.get_clientSeries()},set_ClientSeries:function(t){Sys.Extended.Deprecated("set_ClientSeries","set_clientSeries"),this.set_clientSeries(t)},get_chartType:function(){return this._chartType},set_chartType:function(t){this._chartType=t},get_theme:function(){return this._theme},set_theme:function(t){this._theme=t},get_valueAxisLines:function(){return this._valueAxisLines},set_valueAxisLines:function(t){this._valueAxisLines=t},get_chartTitleColor:function(){return this._chartTitleColor},set_chartTitleColor:function(t){this._chartTitleColor=t},get_valueAxisLineColor:function(){return this._valueAxisLineColor},set_valueAxisLineColor:function(t){this._valueAxisLineColor=t},get_categoryAxisLineColor:function(){return this._categoryAxisLineColor},set_categoryAxisLineColor:function(t){this._categoryAxisLineColor=t},get_baseLineColor:function(){return this._baseLineColor},set_baseLineColor:function(t){this._baseLineColor=t},get_container:function(){return this._container},set_container:function(t){this._container=t}},Sys.Extended.UI.BarChart.registerClass("Sys.Extended.UI.BarChart",Sys.Extended.UI.ControlBase),Sys.Extended.UI.BarChartType=function(){throw Error.invalidOperation()},Sys.Extended.UI.BarChartType.prototype={Column:0,Bar:1,StackedColumn:2,StackedBar:3},Sys.Extended.UI.BarChartType.registerEnum("Sys.Extended.UI.BarChartType",!1);