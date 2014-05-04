<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2006-09-27T01:52:15" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:xdExtension="http://schemas.microsoft.com/office/infopath/2003/xslt/extension" xmlns:xdXDocument="http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument" xmlns:xdSolution="http://schemas.microsoft.com/office/infopath/2003/xslt/solution" xmlns:xdFormatting="http://schemas.microsoft.com/office/infopath/2003/xslt/formatting" xmlns:xdImage="http://schemas.microsoft.com/office/infopath/2003/xslt/xImage" xmlns:xdUtil="http://schemas.microsoft.com/office/infopath/2003/xslt/Util" xmlns:xdMath="http://schemas.microsoft.com/office/infopath/2003/xslt/Math" xmlns:xdDate="http://schemas.microsoft.com/office/infopath/2003/xslt/Date" xmlns:sig="http://www.w3.org/2000/09/xmldsig#" xmlns:xdSignatureProperties="http://schemas.microsoft.com/office/infopath/2003/SignatureProperties" xmlns:ipApp="http://schemas.microsoft.com/office/infopath/2006/XPathExtension/ipApp" xmlns:xdEnvironment="http://schemas.microsoft.com/office/infopath/2006/xslt/environment" xmlns:xdUser="http://schemas.microsoft.com/office/infopath/2006/xslt/User">
    <xsl:output method="html" indent="no"/>
    <xsl:template match="TestRun">
        <html xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <head>
                <meta http-equiv="Content-Type" content="text/html"></meta>
                <style controlStyle="controlStyle">@media screen 			{ 			BODY{margin-left:21px;background-position:21px 0px;} 			} 		BODY{color:windowtext;background-color:window;layout-grid:none;} 		.xdListItem {display:inline-block;width:100%;vertical-align:text-top;} 		.xdListBox,.xdComboBox{margin:1px;} 		.xdInlinePicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) } 		.xdLinkedPicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) url(#default#urn::controls/Binder) } 		.xdSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdRepeatingSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdMultiSelectList{margin:1px;display:inline-block; border:1pt solid #dcdcdc; padding:1px 1px 1px 5px; text-indent:0; color:windowtext; background-color:window; overflow:auto; behavior: url(#default#DataBindingUI) url(#default#urn::controls/Binder) url(#default#MultiSelectHelper) url(#default#ScrollableRegion);} 		.xdMultiSelectListItem{display:block;white-space:nowrap}		.xdMultiSelectFillIn{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:left;}		.xdBehavior_Formatting {BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting);} 	 .xdBehavior_FormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting);} 	.xdExpressionBox{margin: 1px;padding:1px;word-wrap: break-word;text-overflow: ellipsis;overflow-x:hidden;}.xdBehavior_GhostedText,.xdBehavior_GhostedTextNoBUI{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#TextField) url(#default#GhostedText);}	.xdBehavior_GTFormatting{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_GTFormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_Boolean{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#BooleanHelper);}	.xdBehavior_Select{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#SelectHelper);}	.xdBehavior_ComboBox{BEHAVIOR: url(#default#ComboBox)} 	.xdBehavior_ComboBoxTextField{BEHAVIOR: url(#default#ComboBoxTextField);} 	.xdRepeatingTable{BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word;}.xdScrollableRegion{BEHAVIOR: url(#default#ScrollableRegion);} 		.xdLayoutRegion{display:inline-block;} 		.xdMaster{BEHAVIOR: url(#default#MasterHelper);} 		.xdActiveX{margin:1px; BEHAVIOR: url(#default#ActiveX);} 		.xdFileAttachment{display:inline-block;margin:1px;BEHAVIOR:url(#default#urn::xdFileAttachment);} 		.xdPageBreak{display: none;}BODY{margin-right:21px;} 		.xdTextBoxRTL{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:right;word-wrap:normal;} 		.xdRichTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:right;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTTextRTL{height:100%;width:100%;margin-left:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButtonRTL{margin-right:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdMultiSelectFillinRTL{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:right;}.xdTextBox{display:inline-block;white-space:nowrap;text-overflow:ellipsis;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:left;word-wrap:normal;} 		.xdRichTextBox{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-overflow:ellipsis;text-align:left;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTPicker{;display:inline;margin:1px;margin-bottom: 2px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-indent:0} 		.xdDTText{height:100%;width:100%;margin-right:22px;overflow:hidden;padding:0px;white-space:nowrap;} 		.xdDTButton{margin-left:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdRepeatingTable TD {VERTICAL-ALIGN: top;}</style>
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
                <div align="center">
                    <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 342px; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
                        <colgroup>
                            <col style="WIDTH: 170px"></col>
                            <col style="WIDTH: 172px"></col>
                        </colgroup>
                        <tbody vAlign="top">
                            <tr>
                                <td style="BORDER-RIGHT: #9b5d2c 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #9b5d2c 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #9b5d2c 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #9b5d2c 1pt solid; BACKGROUND-COLOR: #ffdaab">
                                    <div>
                                        <font face="Verdana" size="2">
                                            <strong>Overall test results</strong>
                                        </font>
                                    </div>
                                </td>
                                <td style="BORDER-RIGHT: #9b5d2c 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #9b5d2c 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #9b5d2c 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #9b5d2c 1pt solid; BACKGROUND-COLOR: #ffdaab">
                                    <div>
                                        <font face="Verdana" size="2">
                                            <strong>Number of tests </strong>
                                            <span class="xdExpressionBox xdDataBindingUI" title="" xd:CtrlId="CTRL181" xd:xctname="ExpressionBox" tabIndex="-1" xd:disableEditing="yes" style="OVERFLOW-Y: hidden; FONT-WEIGHT: bold; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; WHITE-SPACE: nowrap; WORD-WRAP: normal">
                                                <xsl:value-of select="count(Test)"/>
                                            </span>
                                        </font>
                                    </div>
                                </td>
                            </tr>
                            <tr style="MIN-HEIGHT: 23px">
                                <td style="BORDER-RIGHT: #9b5d2c 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #9b5d2c 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #9b5d2c 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #9b5d2c 1pt solid">
                                    <div>
                                        <font face="Verdana" size="2">
                                            <a href="ALLTESTS_HREF_PASSED" xd:disableEditing="yes">Passed</a>
                                        </font>
                                    </div>
                                </td>
                                <td style="BORDER-RIGHT: #9b5d2c 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #9b5d2c 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #9b5d2c 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #9b5d2c 1pt solid">
                                    <div>
                                        <font face="Verdana" size="2">
                                            <span class="xdExpressionBox xdDataBindingUI" title="" xd:CtrlId="CTRL182" xd:xctname="ExpressionBox" tabIndex="-1" xd:binding="count(Test[Result/@Status = &quot;Passed&quot;])" xd:disableEditing="yes" style="COLOR: #008000">
                                                <xsl:value-of select="count(Test[Result/@Status = &quot;Passed&quot;])"/>
                                            </span>
                                        </font>
                                    </div>
                                </td>
                            </tr>
                            <tr style="MIN-HEIGHT: 23px">
                                <td style="BORDER-RIGHT: #9b5d2c 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #9b5d2c 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #9b5d2c 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #9b5d2c 1pt solid">
                                    <div>
                                        <font face="Verdana" size="2">
                                            <a href="ALLTESTS_HREF_FAILED" xd:disableEditing="yes">Failed</a>
                                        </font>
                                    </div>
                                </td>
                                <td style="BORDER-RIGHT: #9b5d2c 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #9b5d2c 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #9b5d2c 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #9b5d2c 1pt solid">
                                    <div>
                                        <font face="Verdana" size="2">
                                            <span class="xdExpressionBox xdDataBindingUI xdBehavior_Formatting" title="" xd:CtrlId="CTRL183" xd:xctname="ExpressionBox" tabIndex="-1" xd:binding="count(Test[Result/@Status = &quot;Failed&quot;])" xd:datafmt="&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;" xd:disableEditing="yes" style="COLOR: #ff0000">
                                                <xsl:choose>
                                                    <xsl:when test="function-available('xdFormatting:formatString')">
                                                        <xsl:value-of select="xdFormatting:formatString(count(Test[Result/@Status = &quot;Failed&quot;]),&quot;number&quot;,&quot;numDigits:0;negativeOrder:1;&quot;)"/>
                                                    </xsl:when>
                                                    <xsl:otherwise>
                                                        <xsl:value-of select="count(Test[Result/@Status = &quot;Failed&quot;])"/>
                                                    </xsl:otherwise>
                                                </xsl:choose>
                                            </span>
                                        </font>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="BORDER-RIGHT: #9b5d2c 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #9b5d2c 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #9b5d2c 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #9b5d2c 1pt solid">
                                    <div>
                                        <font face="Verdana" size="2">
                                            <a href="ALLTESTS_HREF_UNEXPECTEDERROR" xd:disableEditing="yes">Unexpected Error</a>
                                        </font>
                                    </div>
                                </td>
                                <td style="BORDER-RIGHT: #9b5d2c 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #9b5d2c 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #9b5d2c 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #9b5d2c 1pt solid">
                                    <div>
                                        <font face="Verdana" size="2">
                                            <span class="xdExpressionBox xdDataBindingUI" title="" xd:CtrlId="CTRL184" xd:xctname="ExpressionBox" tabIndex="-1" xd:binding="count(Test[Result/@Status = &quot;UnexpectedError&quot;])" xd:disableEditing="yes" style="COLOR: #ffffff; BACKGROUND-COLOR: #ff0000">
                                                <xsl:value-of select="count(Test[Result/@Status = &quot;UnexpectedError&quot;])"/>
                                            </span>
                                        </font>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </body>
        </html>
    </xsl:template>
</xsl:stylesheet>
