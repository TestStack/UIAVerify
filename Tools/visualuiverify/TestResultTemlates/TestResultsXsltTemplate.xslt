<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2006-09-28T19:28:22" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:xdExtension="http://schemas.microsoft.com/office/infopath/2003/xslt/extension" xmlns:xdXDocument="http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument" xmlns:xdSolution="http://schemas.microsoft.com/office/infopath/2003/xslt/solution" xmlns:xdFormatting="http://schemas.microsoft.com/office/infopath/2003/xslt/formatting" xmlns:xdImage="http://schemas.microsoft.com/office/infopath/2003/xslt/xImage" xmlns:xdUtil="http://schemas.microsoft.com/office/infopath/2003/xslt/Util" xmlns:xdMath="http://schemas.microsoft.com/office/infopath/2003/xslt/Math" xmlns:xdDate="http://schemas.microsoft.com/office/infopath/2003/xslt/Date" xmlns:sig="http://www.w3.org/2000/09/xmldsig#" xmlns:xdSignatureProperties="http://schemas.microsoft.com/office/infopath/2003/SignatureProperties" xmlns:ipApp="http://schemas.microsoft.com/office/infopath/2006/XPathExtension/ipApp" xmlns:xdEnvironment="http://schemas.microsoft.com/office/infopath/2006/xslt/environment" xmlns:xdUser="http://schemas.microsoft.com/office/infopath/2006/xslt/User">
    <xsl:output method="html" indent="no"/>
    <xsl:template match="TestRun">
        <html>
            <head>
                <meta http-equiv="Content-Type" content="text/html"></meta>
                <style controlStyle="controlStyle">@media screen 			{ 			BODY{margin-left:21px;background-position:21px 0px;} 			} 		BODY{color:windowtext;background-color:window;layout-grid:none;} 		.xdListItem {display:inline-block;width:100%;vertical-align:text-top;} 		.xdListBox,.xdComboBox{margin:1px;} 		.xdInlinePicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) } 		.xdLinkedPicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) url(#default#urn::controls/Binder) } 		.xdSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdRepeatingSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdMultiSelectList{margin:1px;display:inline-block; border:1pt solid #dcdcdc; padding:1px 1px 1px 5px; text-indent:0; color:windowtext; background-color:window; overflow:auto; behavior: url(#default#DataBindingUI) url(#default#urn::controls/Binder) url(#default#MultiSelectHelper) url(#default#ScrollableRegion);} 		.xdMultiSelectListItem{display:block;}		.xdMultiSelectFillIn{display:inline-block;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:left;}		.xdBehavior_Formatting {BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting);} 	 .xdBehavior_FormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting);} 	.xdExpressionBox{margin: 1px;padding:1px;word-wrap: break-word;text-overflow: ellipsis;overflow-x:hidden;}.xdBehavior_GhostedText,.xdBehavior_GhostedTextNoBUI{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#TextField) url(#default#GhostedText);}	.xdBehavior_GTFormatting{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_GTFormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_Boolean{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#BooleanHelper);}	.xdBehavior_Select{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#SelectHelper);}	.xdBehavior_ComboBox{BEHAVIOR: url(#default#ComboBox)} 	.xdBehavior_ComboBoxTextField{BEHAVIOR: url(#default#ComboBoxTextField);} 	.xdRepeatingTable{BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word;}.xdScrollableRegion{BEHAVIOR: url(#default#ScrollableRegion);} 		.xdLayoutRegion{display:inline-block;} 		.xdMaster{BEHAVIOR: url(#default#MasterHelper);} 		.xdActiveX{margin:1px; BEHAVIOR: url(#default#ActiveX);} 		.xdFileAttachment{display:inline-block;margin:1px;BEHAVIOR:url(#default#urn::xdFileAttachment);} 		.xdPageBreak{display: none;}BODY{margin-right:21px;} 		.xdTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:right;word-wrap:normal;} 		.xdRichTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:right;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTTextRTL{height:100%;width:100%;margin-left:22px;overflow:hidden;padding:0px;} 		.xdDTButtonRTL{margin-right:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdMultiSelectFillinRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:right;}.xdTextBox{display:inline-block;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:left;word-wrap:normal;} 		.xdRichTextBox{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:left;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTPicker{;display:inline;margin:1px;margin-bottom: 2px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-indent:0} 		.xdDTText{height:100%;width:100%;margin-right:22px;overflow:hidden;padding:0px;} 		.xdDTButton{margin-left:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdRepeatingTable TD {VERTICAL-ALIGN: top;}</style>
                <style tableEditor="TableStyleRulesID">
                    TABLE.xdLayout TD {
                    BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none
                    }
                    TABLE.msoUcTable TD {
                    BORDER-RIGHT: 1pt solid; BORDER-TOP: 1pt solid; BORDER-LEFT: 1pt solid; BORDER-BOTTOM: 1pt solid
                    }
                    TABLE {
                    BEHAVIOR: url (#default#urn::tables/NDTable)
                    }
                </style>
                <style languageStyle="languageStyle">
                    BODY {
                    FONT-SIZE: 10pt; FONT-FAMILY: Verdana
                    }
                    TABLE {
                    FONT-SIZE: 10pt; FONT-FAMILY: Verdana
                    }
                    SELECT {
                    FONT-SIZE: 10pt; FONT-FAMILY: Verdana
                    }
                    .optionalPlaceholder {
                    PADDING-LEFT: 20px; FONT-WEIGHT: normal; FONT-SIZE: xx-small; BEHAVIOR: url(#default#xOptional); COLOR: #333333; FONT-STYLE: normal; FONT-FAMILY: Verdana; TEXT-DECORATION: none
                    }
                    .langFont {
                    FONT-FAMILY: Verdana
                    }
                    .defaultInDocUI {
                    FONT-SIZE: xx-small; FONT-FAMILY: Verdana
                    }
                    .optionalPlaceholder {
                    PADDING-RIGHT: 20px
                    }
                </style>
                <style themeStyle="urn:office.microsoft.com:themeMahogany">
                    BODY {
                    COLOR: black; BACKGROUND-COLOR: white
                    }
                    TABLE {
                    BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse
                    }
                    TD {
                    BORDER-LEFT-COLOR: #9b5d2c; BORDER-BOTTOM-COLOR: #9b5d2c; BORDER-TOP-COLOR: #9b5d2c; BORDER-RIGHT-COLOR: #9b5d2c
                    }
                    TH {
                    BORDER-LEFT-COLOR: #9b5d2c; BORDER-BOTTOM-COLOR: #9b5d2c; COLOR: black; BORDER-TOP-COLOR: #9b5d2c; BACKGROUND-COLOR: #d3a04f; BORDER-RIGHT-COLOR: #9b5d2c
                    }
                    .xdTableHeader {
                    COLOR: black; BACKGROUND-COLOR: #ffdaab
                    }
                    P {
                    MARGIN-TOP: 0px
                    }
                    H1 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #61000a
                    }
                    H2 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #61000a
                    }
                    H3 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #61000a
                    }
                    H4 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #61000a
                    }
                    H5 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #9b5d2c
                    }
                    H6 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #ffdaab
                    }
                    .primaryVeryDark {
                    COLOR: #ffdaab; BACKGROUND-COLOR: #61000a
                    }
                    .primaryDark {
                    COLOR: white; BACKGROUND-COLOR: #9b5d2c
                    }
                    .primaryMedium {
                    COLOR: black; BACKGROUND-COLOR: #d3a04f
                    }
                    .primaryLight {
                    COLOR: black; BACKGROUND-COLOR: #ffdaab
                    }
                    .accentDark {
                    COLOR: white; BACKGROUND-COLOR: #5c73b6
                    }
                    .accentLight {
                    COLOR: black; BACKGROUND-COLOR: #bfcefa
                    }
                </style>
            </head>
            <body style="COLOR: #000000; BACKGROUND-COLOR: #ffffff">
                <div> </div>
                <div/>
                <div>
                    <a name="UnexpectedError" />
                    <table class="xdRepeatingTable msoUcTable" title="" style="TABLE-LAYOUT: fixed; WIDTH:100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1" xd:CtrlId="CTRL1">
                        <colgroup>
                            <col></col>
                        </colgroup>
                        <tbody class="xdTableHeader">
                            <tr>
                                <td style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; PADDING-TOP: 1px; BACKGROUND-COLOR: #c00b02>">
                                    <div>
                                        <font style="BACKGROUND-COLOR: #c00b02" backcolor="#c00b02" color="#f8eee0">
                                            <strong>
                                                Tests caused Unexpected Error:
                                                <span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" xd:CtrlId="CTRL65" tabIndex="-1" xd:datafmt="&quot;number&quot;,&quot;numDigits:auto;negativeOrder:1;&quot;" xd:disableEditing="yes" xd:binding="count(Test[Result/@Status = &quot;UnexpectedError&quot;])" xd:xctname="ExpressionBox" style="OVERFLOW-Y: hidden; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; COLOR: #ffffff;  WORD-WRAP: normal">
                                                    <xsl:choose>
                                                        <xsl:when test="function-available('xdFormatting:formatString')">
                                                            <xsl:value-of select="xdFormatting:formatString(count(Test[Result/@Status = &quot;UnexpectedError&quot;]),&quot;number&quot;,&quot;numDigits:auto;negativeOrder:1;&quot;)"/>
                                                        </xsl:when>
                                                        <xsl:otherwise>
                                                            <xsl:value-of select="count(Test[Result/@Status = &quot;UnexpectedError&quot;])"/>
                                                        </xsl:otherwise>
                                                    </xsl:choose>
                                                </span>
                                            </strong>
                                        </font>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                        <tbody xd:xctname="RepeatingTable">
                            <xsl:for-each select="Test [ (Result/@Status = &quot;UnexpectedError&quot;) ] ">
                                <tr>
                                    <td style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; PADDING-TOP: 1px">
                                        <div>
                                            <div class="xdSection xdRepeating" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" xd:xctname="choicegrouprepeating" xd:ref="TestInfo">
                                                <xsl:apply-templates select="TestInfo/Author" mode="_11"/>
                                            </div>
                                        </div>
                                        <div>
                                            <xsl:apply-templates select="Messages/Exception" mode="_50"/>

                                        </div>
                                    </td>
                                </tr>
                            </xsl:for-each>
                        </tbody>
                    </table>
                </div>
                <div> </div>
                <div>
                    <a name="Failed" />

                    <table class="xdRepeatingTable msoUcTable" title="" style="TABLE-LAYOUT: fixed; WIDTH: 100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1" xd:CtrlId="CTRL23">
                        <colgroup>
                            <col></col>
                        </colgroup>
                        <tbody class="xdTableHeader">
                            <tr>
                                <td style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; PADDING-TOP: 1px">
                                    <div>
                                        <font style="BACKGROUND-COLOR: #ffdaab" color="#ff0000">
                                            <strong>Tests Failed: </strong>
                                        </font>
                                        <strong>
                                            <font color="#ff0000">
                                                <span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" xd:CtrlId="CTRL66" tabIndex="-1" xd:datafmt="&quot;number&quot;,&quot;numDigits:auto;negativeOrder:1;&quot;" xd:disableEditing="yes" xd:binding="count(Test[Result/@Status = &quot;Failed&quot;])" xd:xctname="ExpressionBox" style="OVERFLOW-Y: hidden; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; COLOR: #ff0000;  WORD-WRAP: normal">
                                                    <xsl:choose>
                                                        <xsl:when test="function-available('xdFormatting:formatString')">
                                                            <xsl:value-of select="xdFormatting:formatString(count(Test[Result/@Status = &quot;Failed&quot;]),&quot;number&quot;,&quot;numDigits:auto;negativeOrder:1;&quot;)"/>
                                                        </xsl:when>
                                                        <xsl:otherwise>
                                                            <xsl:value-of select="count(Test[Result/@Status = &quot;Failed&quot;])"/>
                                                        </xsl:otherwise>
                                                    </xsl:choose>
                                                </span>
                                            </font>
                                        </strong>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                        <tbody xd:xctname="RepeatingTable">
                            <xsl:for-each select="Test [ (Result/@Status = &quot;Failed&quot;)  ] ">
                                <tr>
                                    <td>
                                        <div>
                                            <div class="xdSection xdRepeating" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" xd:xctname="choicegrouprepeating" xd:ref="TestInfo">
                                                <xsl:apply-templates select="TestInfo/Author" mode="_51"/>
                                            </div>
                                        </div>
                                        <div>
                                            <xsl:apply-templates select="Messages/Exception" mode="_53"/>

                                        </div>
                                    </td>
                                </tr>
                            </xsl:for-each>
                        </tbody>
                    </table>
                </div>
                <div> </div>
                <div>
                    <a name="Passed" />

                    <table class="xdRepeatingTable msoUcTable" title="" style="TABLE-LAYOUT: fixed; WIDTH: 100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1" xd:CtrlId="CTRL44">
                        <colgroup>
                            <col></col>
                        </colgroup>
                        <tbody class="xdTableHeader">
                            <tr style="MIN-HEIGHT: 19px">
                                <td style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; PADDING-TOP: 1px">
                                    <div>
                                        <font style="BACKGROUND-COLOR: #ffdaab" color="#008000">
                                            <strong>Tests Passed:</strong>
                                        </font>
                                        <strong>
                                            <font color="#ff0000">
                                                <span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" xd:CtrlId="CTRL67" tabIndex="-1" xd:datafmt="&quot;number&quot;,&quot;numDigits:auto;negativeOrder:1;&quot;" xd:disableEditing="yes" xd:binding="count(Test[Result/@Status = &quot;Passed&quot;])" xd:xctname="ExpressionBox" style="OVERFLOW-Y: hidden; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; COLOR: #008000;  WORD-WRAP: normal">
                                                    <xsl:choose>
                                                        <xsl:when test="function-available('xdFormatting:formatString')">
                                                            <xsl:value-of select="xdFormatting:formatString(count(Test[Result/@Status = &quot;Passed&quot;]),&quot;number&quot;,&quot;numDigits:auto;negativeOrder:1;&quot;)"/>
                                                        </xsl:when>
                                                        <xsl:otherwise>
                                                            <xsl:value-of select="count(Test[Result/@Status = &quot;Passed&quot;])"/>
                                                        </xsl:otherwise>
                                                    </xsl:choose>
                                                </span>
                                            </font>
                                        </strong>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                        <tbody xd:xctname="RepeatingTable">
                            <xsl:for-each select="Test [ (Result/@Status = &quot;Passed&quot;)  ] ">
                                <tr>
                                    <td style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: top; PADDING-TOP: 1px">
                                        <div>
                                            <font face="Verdana" size="2">
                                                <strong>Test Name : </strong>
                                            </font>
                                            <span class="xdHyperlink" hideFocus="1" title="" style="OVERFLOW: visible; TEXT-ALIGN: left" xd:xctname="hyperlink">
                                                <a class="xdDataBindingUI" xd:CtrlId="CTRL103" xd:disableEditing="yes">
                                                    <xsl:attribute name="href">
                                                        TEMP_FILES_PREFIX.test<xsl:value-of select="@Id"/>.xml
                                                    </xsl:attribute>
                                                    <xsl:value-of select="TestInfo/Name"/>
                                                </a>
                                            </span>
                                        </div>
                                    </td>
                                </tr>
                            </xsl:for-each>
                        </tbody>
                    </table>
                </div>
            </body>
        </html>
    </xsl:template>
    <xsl:template match="Author" mode="_11">
        <div class="xdSection xdRepeating" title="" style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px" align="left" xd:CtrlId="CTRL2" xd:xctname="choicetermrepeating" tabIndex="-1">
            <div>
                <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 100%; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
                    <colgroup>
                        <col style="WIDTH: 96px"></col>
                        <col style="WIDTH: 100%"></col>
                    </colgroup>
                    <tbody vAlign="top">
                        <tr>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid; BACKGROUND-COLOR: #c0c0c0">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Test Name :</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid; BACKGROUND-COLOR: #c0c0c0">
                                <div>
                                    <span class="xdHyperlink" hideFocus="1" title="" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW: visible; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; TEXT-ALIGN: left" xd:xctname="hyperlink">
                                        <a class="xdDataBindingUI" xd:CtrlId="CTRL90" xd:disableEditing="yes">
                                            <xsl:attribute name="href">
                                                TEMP_FILES_PREFIX.test<xsl:value-of select="../../@Id"/>.xml
                                            </xsl:attribute>
                                            <xsl:value-of select="../Name"/>
                                        </a>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Result Status:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; BORDER-LEFT: #c0c0c0 1pt solid; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL114" tabIndex="0" xd:binding="../../Result/@Status" xd:xctname="PlainText" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt">
                                        <xsl:value-of select="../../Result/@Status"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Test Priority:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; BORDER-LEFT: #c0c0c0 1pt solid; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL5" tabIndex="-1" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:disableEditing="yes" xd:binding="../Priority" xd:xctname="PlainText" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; WORD-WRAP: break-word">
                                        <xsl:choose>
                                            <xsl:when test="function-available('xdFormatting:formatString')">
                                                <xsl:value-of select="xdFormatting:formatString(../Priority,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                                            </xsl:when>
                                            <xsl:otherwise>
                                                <xsl:value-of select="../Priority" disable-output-escaping="yes"/>
                                            </xsl:otherwise>
                                        </xsl:choose>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr style="MIN-HEIGHT: 26px">
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: top; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Description:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; BORDER-LEFT: #c0c0c0 1pt solid; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL13" tabIndex="-1" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:disableEditing="yes" xd:binding="../Description" xd:xctname="PlainText" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; WORD-WRAP: break-word">
                                        <xsl:choose>
                                            <xsl:when test="function-available('xdFormatting:formatString')">
                                                <xsl:value-of select="xdFormatting:formatString(../Description,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                                            </xsl:when>
                                            <xsl:otherwise>
                                                <xsl:value-of select="../Description" disable-output-escaping="yes"/>
                                            </xsl:otherwise>
                                        </xsl:choose>
                                    </span>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </xsl:template>
    <xsl:template match="Exception" mode="_50">
        <div class="xdRepeatingSection xdRepeating" title="" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" align="left" xd:CtrlId="CTRL108" xd:xctname="RepeatingSection" tabIndex="-1">
            <div>
                <strong>
                    <font color="#bb0000">!! Exception !!</font>
                </strong>
            </div>
            <div>
                <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 100%; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
                    <colgroup>
                        <col style="WIDTH: 20px"></col>
                        <col style="WIDTH: 20px"></col>
                        <col style="WIDTH: 20px"></col>
                    </colgroup>
                    <tbody vAlign="top">
                        <tr>
                            <td colSpan="3" style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
                                <div>
                                    Message: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL112" tabIndex="-1" xd:disableEditing="yes" xd:binding="Message" xd:xctname="PlainText" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; FONT-WEIGHT: bold; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; ">
                                        <xsl:value-of select="Message"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr style="MIN-HEIGHT: 19px">
                            <td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
                                <div>
                                    <font face="Verdana" size="2">
                                        Unexpected: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL109" tabIndex="-1" xd:disableEditing="yes" xd:binding="@Unexpected" xd:xctname="PlainText">
                                            <xsl:attribute name="style">
                                                BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; FONT-STYLE: italic; <xsl:choose>
                                                    <xsl:when test="@Unexpected = &quot;true&quot;">COLOR: #ff0000</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                            <xsl:value-of select="@Unexpected"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
                                <div>
                                    <font face="Verdana" size="2">
                                        Known Bug: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL110" tabIndex="-1" xd:disableEditing="yes" xd:binding="@KnownBug" xd:xctname="PlainText">
                                            <xsl:attribute name="style">
                                                BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; FONT-STYLE: italic; <xsl:choose>
                                                    <xsl:when test="@KnownBug = &quot;false&quot; and @IncorrectConfiguration = &quot;false&quot;">COLOR: #ff0000</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                            <xsl:value-of select="@KnownBug"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
                                <div>
                                    <font face="Verdana" size="2">
                                        Incorrect Configuration: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL111" tabIndex="-1" xd:disableEditing="yes" xd:binding="@IncorrectConfiguration" xd:xctname="PlainText">
                                            <xsl:attribute name="style">
                                                BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; FONT-STYLE: italic; <xsl:choose>
                                                    <xsl:when test="@IncorrectConfiguration = &quot;false&quot; and @KnownBug = &quot;false&quot;">COLOR: #ff0000</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                            <xsl:value-of select="@IncorrectConfiguration"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div> </div>
            <div>
                Stack Trace: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL113" tabIndex="-1" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:disableEditing="yes" xd:binding="StackTrace" xd:xctname="PlainText" style="OVERFLOW-Y: visible; OVERFLOW-X: visible; WIDTH: 100%; WHITE-SPACE: normal; WORD-WRAP: break-word">
                    <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                            <xsl:value-of select="xdFormatting:formatString(StackTrace,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:value-of select="StackTrace" disable-output-escaping="yes"/>
                        </xsl:otherwise>
                    </xsl:choose>
                </span>
            </div>
        </div>
    </xsl:template>
    <xsl:template match="Author" mode="_51">
        <div class="xdSection xdRepeating" title="" style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px" align="left" xd:CtrlId="CTRL115" xd:xctname="choicetermrepeating" tabIndex="-1">
            <div>
                <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 100%; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
                    <colgroup>
                        <col style="WIDTH: 96px"></col>
                        <col style="WIDTH: 100%"></col>
                    </colgroup>
                    <tbody vAlign="top">
                        <tr>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid; BACKGROUND-COLOR: #c0c0c0">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Test Name :</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid; BACKGROUND-COLOR: #c0c0c0">
                                <div>
                                    <span class="xdHyperlink" hideFocus="1" title="" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW: visible; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; TEXT-ALIGN: left" xd:xctname="hyperlink">
                                        <a class="xdDataBindingUI" xd:CtrlId="CTRL116" xd:disableEditing="yes">
                                            <xsl:attribute name="href">
                                                TEMP_FILES_PREFIX.test<xsl:value-of select="../../@Id"/>.xml
                                            </xsl:attribute>
                                            <xsl:value-of select="../Name"/>
                                        </a>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Result Status:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; BORDER-LEFT: #c0c0c0 1pt solid; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL117" tabIndex="0" xd:binding="../../Result/@Status" xd:xctname="PlainText" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt">
                                        <xsl:value-of select="../../Result/@Status"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr style="MIN-HEIGHT: 21px">
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Test Priority:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; BORDER-LEFT: #c0c0c0 1pt solid; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL118" tabIndex="-1" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:disableEditing="yes" xd:binding="../Priority" xd:xctname="PlainText" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; WORD-WRAP: break-word">
                                        <xsl:choose>
                                            <xsl:when test="function-available('xdFormatting:formatString')">
                                                <xsl:value-of select="xdFormatting:formatString(../Priority,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                                            </xsl:when>
                                            <xsl:otherwise>
                                                <xsl:value-of select="../Priority" disable-output-escaping="yes"/>
                                            </xsl:otherwise>
                                        </xsl:choose>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr style="MIN-HEIGHT: 26px">
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #c0c0c0 1pt solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: top; BORDER-LEFT: #c0c0c0 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Description:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; BORDER-LEFT: #c0c0c0 1pt solid; BORDER-BOTTOM: #c0c0c0 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL119" tabIndex="-1" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:disableEditing="yes" xd:binding="../Description" xd:xctname="PlainText" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; WORD-WRAP: break-word">
                                        <xsl:choose>
                                            <xsl:when test="function-available('xdFormatting:formatString')">
                                                <xsl:value-of select="xdFormatting:formatString(../Description,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                                            </xsl:when>
                                            <xsl:otherwise>
                                                <xsl:value-of select="../Description" disable-output-escaping="yes"/>
                                            </xsl:otherwise>
                                        </xsl:choose>
                                    </span>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </xsl:template>
    <xsl:template match="Exception" mode="_53">
        <div class="xdRepeatingSection xdRepeating" title="" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" align="left" xd:CtrlId="CTRL120" xd:xctname="RepeatingSection" tabIndex="-1">
            <div>
                <strong>
                    <font color="#800000">!! Exception !!</font>
                </strong>
            </div>
            <div>
                <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH:100%; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
                    <colgroup>
                        <col style="WIDTH: 20px"></col>
                        <col style="WIDTH: 20px"></col>
                        <col style="WIDTH: 20px"></col>
                    </colgroup>
                    <tbody vAlign="top">
                        <tr>
                            <td colSpan="3" style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
                                <div>
                                    Message: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL121" tabIndex="-1" xd:disableEditing="yes" xd:binding="Message" xd:xctname="PlainText" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; FONT-WEIGHT: bold; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt;">
                                        <xsl:value-of select="Message"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr style="MIN-HEIGHT: 19px">
                            <td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
                                <div>
                                    <font face="Verdana" size="2">
                                        Unexpected: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL122" tabIndex="-1" xd:disableEditing="yes" xd:binding="@Unexpected" xd:xctname="PlainText">
                                            <xsl:attribute name="style">
                                                BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; FONT-STYLE: italic; <xsl:choose>
                                                    <xsl:when test="@Unexpected = &quot;true&quot;">COLOR: #ff0000</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                            <xsl:value-of select="@Unexpected"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
                                <div>
                                    <font face="Verdana" size="2">
                                        Known Bug: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL123" tabIndex="-1" xd:disableEditing="yes" xd:binding="@KnownBug" xd:xctname="PlainText">
                                            <xsl:attribute name="style">
                                                BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; FONT-STYLE: italic; <xsl:choose>
                                                    <xsl:when test="@KnownBug = &quot;false&quot; and @IncorrectConfiguration = &quot;false&quot;">COLOR: #ff0000</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                            <xsl:value-of select="@KnownBug"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none">
                                <div>
                                    <font face="Verdana" size="2">
                                        Incorrect Configuration: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL124" tabIndex="-1" xd:disableEditing="yes" xd:binding="@IncorrectConfiguration" xd:xctname="PlainText">
                                            <xsl:attribute name="style">
                                                BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; FONT-STYLE: italic; <xsl:choose>
                                                    <xsl:when test="@IncorrectConfiguration = &quot;false&quot; and @KnownBug = &quot;false&quot;">COLOR: #ff0000</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                            <xsl:value-of select="@IncorrectConfiguration"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div> </div>
            <div>
                Stack Trace:
                <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL125" tabIndex="-1" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:disableEditing="yes" xd:binding="StackTrace" xd:xctname="PlainText" style="OVERFLOW-Y: visible; OVERFLOW-X: visible; WIDTH: 100%; WHITE-SPACE: normal; WORD-WRAP: break-word">
                    <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                            <xsl:value-of select="xdFormatting:formatString(StackTrace,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:value-of select="StackTrace" disable-output-escaping="yes"/>
                        </xsl:otherwise>
                    </xsl:choose>
                </span>
            </div>
        </div>
    </xsl:template>
</xsl:stylesheet>
