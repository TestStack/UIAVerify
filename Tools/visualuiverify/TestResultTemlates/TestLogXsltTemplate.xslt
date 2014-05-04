<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:my="http://schemas.microsoft.com/office/infopath/2003/myXSD/2006-10-11T21:18:04" xmlns:xd="http://schemas.microsoft.com/office/infopath/2003" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns:xdExtension="http://schemas.microsoft.com/office/infopath/2003/xslt/extension" xmlns:xdXDocument="http://schemas.microsoft.com/office/infopath/2003/xslt/xDocument" xmlns:xdSolution="http://schemas.microsoft.com/office/infopath/2003/xslt/solution" xmlns:xdFormatting="http://schemas.microsoft.com/office/infopath/2003/xslt/formatting" xmlns:xdImage="http://schemas.microsoft.com/office/infopath/2003/xslt/xImage" xmlns:xdUtil="http://schemas.microsoft.com/office/infopath/2003/xslt/Util" xmlns:xdMath="http://schemas.microsoft.com/office/infopath/2003/xslt/Math" xmlns:xdDate="http://schemas.microsoft.com/office/infopath/2003/xslt/Date" xmlns:sig="http://www.w3.org/2000/09/xmldsig#" xmlns:xdSignatureProperties="http://schemas.microsoft.com/office/infopath/2003/SignatureProperties" xmlns:ipApp="http://schemas.microsoft.com/office/infopath/2006/XPathExtension/ipApp" xmlns:xdEnvironment="http://schemas.microsoft.com/office/infopath/2006/xslt/environment" xmlns:xdUser="http://schemas.microsoft.com/office/infopath/2006/xslt/User">
    <xsl:output method="html" indent="no"/>
    <xsl:template match="Test">
        <html xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <head>
                <meta http-equiv="Content-Type" content="text/html"></meta>
                <style controlStyle="controlStyle">@media screen 			{ 			BODY{margin-left:21px;background-position:21px 0px;} 			} 		BODY{color:windowtext;background-color:window;layout-grid:none;} 		.xdListItem {display:inline-block;width:100%;vertical-align:text-top;} 		.xdListBox,.xdComboBox{margin:1px;} 		.xdInlinePicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) } 		.xdLinkedPicture{margin:1px; BEHAVIOR: url(#default#urn::xdPicture) url(#default#urn::controls/Binder) } 		.xdSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdRepeatingSection{border:1pt solid #FFFFFF;margin:6px 0px 6px 0px;padding:1px 1px 1px 5px;} 		.xdMultiSelectList{margin:1px;display:inline-block; border:1pt solid #dcdcdc; padding:1px 1px 1px 5px; text-indent:0; color:windowtext; background-color:window; overflow:auto; behavior: url(#default#DataBindingUI) url(#default#urn::controls/Binder) url(#default#MultiSelectHelper) url(#default#ScrollableRegion);} 		.xdMultiSelectListItem{display:block;}		.xdMultiSelectFillIn{display:inline-block;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:left;}		.xdBehavior_Formatting {BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting);} 	 .xdBehavior_FormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting);} 	.xdExpressionBox{margin: 1px;padding:1px;word-wrap: break-word;text-overflow: ellipsis;overflow-x:hidden;}.xdBehavior_GhostedText,.xdBehavior_GhostedTextNoBUI{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#TextField) url(#default#GhostedText);}	.xdBehavior_GTFormatting{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_GTFormattingNoBUI{BEHAVIOR: url(#default#CalPopup) url(#default#urn::controls/Binder) url(#default#Formatting) url(#default#GhostedText);}	.xdBehavior_Boolean{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#BooleanHelper);}	.xdBehavior_Select{BEHAVIOR: url(#default#urn::controls/Binder) url(#default#SelectHelper);}	.xdBehavior_ComboBox{BEHAVIOR: url(#default#ComboBox)} 	.xdBehavior_ComboBoxTextField{BEHAVIOR: url(#default#ComboBoxTextField);} 	.xdRepeatingTable{BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word;}.xdScrollableRegion{BEHAVIOR: url(#default#ScrollableRegion);} 		.xdLayoutRegion{display:inline-block;} 		.xdMaster{BEHAVIOR: url(#default#MasterHelper);} 		.xdActiveX{margin:1px; BEHAVIOR: url(#default#ActiveX);} 		.xdFileAttachment{display:inline-block;margin:1px;BEHAVIOR:url(#default#urn::xdFileAttachment);} 		.xdPageBreak{display: none;}BODY{margin-right:21px;} 		.xdTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:right;word-wrap:normal;} 		.xdRichTextBoxRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-align:right;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTTextRTL{height:100%;width:100%;margin-left:22px;overflow:hidden;padding:0px;} 		.xdDTButtonRTL{margin-right:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdMultiSelectFillinRTL{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;overflow:hidden;text-align:right;}.xdTextBox{display:inline-block;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-align:left;word-wrap:normal;} 		.xdRichTextBox{display:inline-block;;padding:1px;margin:1px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow-x:hidden;word-wrap:break-word;text-align:left;font-weight:normal;font-style:normal;text-decoration:none;vertical-align:baseline;} 		.xdDTPicker{;display:inline;margin:1px;margin-bottom: 2px;border: 1pt solid #dcdcdc;color:windowtext;background-color:window;overflow:hidden;text-indent:0} 		.xdDTText{height:100%;width:100%;margin-right:22px;overflow:hidden;padding:0px;} 		.xdDTButton{margin-left:-21px;height:18px;width:20px;behavior: url(#default#DTPicker);} 		.xdRepeatingTable TD {VERTICAL-ALIGN: top;}</style>
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
                <style themeStyle="urn:office.microsoft.com:themeRed">
                    BODY {
                    COLOR: black; BACKGROUND-COLOR: white
                    }
                    TABLE {
                    BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse
                    }
                    TD {
                    BORDER-LEFT-COLOR: #f61208; BORDER-BOTTOM-COLOR: #f61208; BORDER-TOP-COLOR: #f61208; BORDER-RIGHT-COLOR: #f61208
                    }
                    TH {
                    BORDER-LEFT-COLOR: #f61208; BORDER-BOTTOM-COLOR: #f61208; COLOR: black; BORDER-TOP-COLOR: #f61208; BACKGROUND-COLOR: #fed3d1; BORDER-RIGHT-COLOR: #f61208
                    }
                    .xdTableHeader {
                    COLOR: black; BACKGROUND-COLOR: #f8eee0
                    }
                    P {
                    MARGIN-TOP: 0px
                    }
                    H1 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #c00b02
                    }
                    H2 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #c00b02
                    }
                    H3 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #c00b02
                    }
                    H4 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #c00b02
                    }
                    H5 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #f61208
                    }
                    H6 {
                    MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; COLOR: #f8eee0
                    }
                    .primaryVeryDark {
                    COLOR: #f8eee0; BACKGROUND-COLOR: #c00b02
                    }
                    .primaryDark {
                    COLOR: white; BACKGROUND-COLOR: #f61208
                    }
                    .primaryMedium {
                    COLOR: black; BACKGROUND-COLOR: #fed3d1
                    }
                    .primaryLight {
                    COLOR: black; BACKGROUND-COLOR: #f8eee0
                    }
                    .accentDark {
                    COLOR: white; BACKGROUND-COLOR: #f61208
                    }
                    .accentLight {
                    COLOR: black; BACKGROUND-COLOR: #f8eee0
                    }
                </style>
            </head>
            <body style="COLOR: #000000; BACKGROUND-COLOR: #ffffff">
                <div/>
                <div>
                    <strong>
                        <font size="4">Test result:</font>
                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="Result/@Status" xd:xctname="PlainText" xd:CtrlId="CTRL35">
                            <xsl:attribute name="style">
                                BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; FONT-WEIGHT: bold; FONT-SIZE: medium; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent;<xsl:choose>
                                    <xsl:when test="Result/@Status = &quot;Passed&quot;">COLOR: #008000</xsl:when>
                                    <xsl:when test="Result/@Status = &quot;Failed&quot;">COLOR: #ff0000</xsl:when>
                                    <xsl:when test="Result/@Status = &quot;UnexpectedError&quot;">COLOR: #ffffff; BACKGROUND-COLOR: #c00d02</xsl:when>
                                </xsl:choose>
                            </xsl:attribute>
                            <xsl:value-of select="Result/@Status"/>
                        </span>
                    </strong>
                </div>
                <div> </div>
                <div>
                    <xsl:apply-templates select="." mode="_19"/>
                </div>
            </body>
        </html>
    </xsl:template>
    <xsl:template match="Test" mode="_19">
        <div class="xdSection xdRepeating" title="" style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; MARGIN-BOTTOM: 6px; PADDING-BOTTOM: 0px; WIDTH: 100%; PADDING-TOP: 0px" align="left" xd:xctname="Section" xd:CtrlId="CTRL3" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <div>
                <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 100%; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse;" borderColor="buttontext" border="1">
                    <colgroup>
                        <col style="WIDTH: 120px"></col>
                        <col style="WIDTH: 100%"></col>
                    </colgroup>
                    <tbody vAlign="top">
                        <tr style="MIN-HEIGHT: 17px">
                            <td colSpan="2" style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid; BACKGROUND-COLOR: #ffdaab">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Test info</strong>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Name:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="TestInfo/Name" xd:xctname="PlainText" xd:CtrlId="CTRL36" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; FONT-WEIGHT: bold; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                            <xsl:value-of select="TestInfo/Name"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Priority:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="TestInfo/Priority" xd:xctname="PlainText" xd:CtrlId="CTRL7" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                            <xsl:value-of select="TestInfo/Priority"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Status:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="TestInfo/Status" xd:xctname="PlainText" xd:CtrlId="CTRL37" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                            <xsl:value-of select="TestInfo/Status"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Author:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="TestInfo/Author" xd:xctname="PlainText" xd:CtrlId="CTRL9" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                            <xsl:value-of select="TestInfo/Author"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>TestCaseType:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="TestInfo/TestCaseType" xd:xctname="PlainText" xd:CtrlId="CTRL10" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                            <xsl:value-of select="TestInfo/TestCaseType"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Description:</strong>
                                    </font>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <span class="xdRepeating" title="" style="MARGIN-BOTTOM: 1px; WIDTH: 100%" xd:xctname="BulletedList">
                                        <ol style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LIST-STYLE-TYPE: disc">
                                            <xsl:for-each select="TestInfo/Description">
                                                <li>
                                                    <span class="xdListItem" hideFocus="1" tabIndex="0" xd:binding="." xd:xctname="ListItem_Plain" xd:CtrlId="CTRL11" style="WIDTH: 100%">
                                                        <xsl:value-of select="."/>
                                                    </span>
                                                </li>
                                            </xsl:for-each>
                                        </ol>
                                    </span>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div> </div>
            <div>
                <table class="msoUcTable" style="TABLE-LAYOUT: fixed; WIDTH: 100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; BORDER-BOTTOM-STYLE: none" border="1">
                    <colgroup>
                        <col style="WIDTH: 120px"></col>
                        <col style="WIDTH: 100%"></col>
                    </colgroup>
                    <tbody>
                        <tr style="MIN-HEIGHT: 19px">
                            <td colSpan="2" style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid; BACKGROUND-COLOR: #ffdaab">
                                <div>
                                    <strong>Method info</strong>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <strong>Assembly File:</strong>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="TestInfo/MethodInfo/AssemblyFile" xd:xctname="PlainText" xd:CtrlId="CTRL38" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                        <xsl:value-of select="TestInfo/MethodInfo/AssemblyFile"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <strong>Class:</strong>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="TestInfo/MethodInfo/Class" xd:xctname="PlainText" xd:CtrlId="CTRL39" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                        <xsl:value-of select="TestInfo/MethodInfo/Class"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <strong>Method:</strong>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="TestInfo/MethodInfo/Method" xd:xctname="PlainText" xd:CtrlId="CTRL40" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                        <xsl:value-of select="TestInfo/MethodInfo/Method"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div> </div>
            <div>
                <table class="msoUcTable" style="TABLE-LAYOUT: fixed; WIDTH: 100%; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; BORDER-BOTTOM-STYLE: none" border="1">
                    <colgroup>
                        <col style="WIDTH: 160px"></col>
                        <col style="WIDTH: 100%"></col>
                    </colgroup>
                    <tbody>
                        <tr>
                            <td colSpan="2" style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid; BACKGROUND-COLOR: #ffdaab">
                                <div>
                                    <strong>Automation Element</strong>
                                </div>
                            </td>
                        </tr>
                        <tr style="MIN-HEIGHT: 26px">
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <strong>Element Runtime Id:</strong>
                                </div>
                            </td>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>
                                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="-1" xd:binding="TestInfo/AutomationElement/@ElementRuntimeId" xd:xctname="PlainText" xd:CtrlId="CTRL41" xd:disableEditing="yes" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt;  BACKGROUND-COLOR: transparent">
                                        <xsl:value-of select="TestInfo/AutomationElement/@ElementRuntimeId"/>
                                    </span>
                                </div>
                            </td>
                        </tr>
                        <tr style="MIN-HEIGHT: 26px">
                            <td colSpan="2" style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid">
                                <div>Path to element: </div>
                                <div>
                                    <xsl:apply-templates select="TestInfo/AutomationElement/ElementPath" mode="_36"/>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div> </div>
            <div>
                <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 100%; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse" borderColor="buttontext" border="1">
                    <colgroup>
                        <col style="WIDTH: 100%"></col>
                    </colgroup>
                    <tbody vAlign="top">
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid; BACKGROUND-COLOR: #ffdaab">
                                <div>
                                    <font face="Verdana" size="2">
                                        <strong>Messages</strong>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="BORDER-RIGHT: #993300 1pt solid; BORDER-TOP: #993300 1pt solid; BORDER-LEFT: #993300 1pt solid; BORDER-BOTTOM: #993300 1pt solid; BACKGROUND-COLOR: #fdf7c8">
                                <div>
                                    <div class="xdSection xdRepeating" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" xd:xctname="choicegrouprepeating" xd:ref="Messages">
                                        <xsl:apply-templates select="Messages/Comment|Messages/Exception" mode="_41"/>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </xsl:template>
    <xsl:template match="ElementPath" mode="_36">
        <div class="xdSection xdRepeating" title="" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" align="left" xd:xctname="Section" xd:CtrlId="CTRL67" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <div>
                <xsl:apply-templates select="Path" mode="_37"/>
            </div>
        </div>
    </xsl:template>
    <xsl:template match="Path" mode="_37">
        <div class="xdSection xdRepeating" title="" style="PADDING-LEFT: 10px; MARGIN-BOTTOM: 6px; WIDTH: 100%" align="left" xd:xctname="Section" xd:CtrlId="CTRL68" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <div>Element: </div>
            <ul style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px" type="disc">
                <li>
                    <strong>Name=</strong>
                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="-1" xd:binding="@Name" xd:xctname="PlainText" xd:CtrlId="CTRL72" xd:disableEditing="yes" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: -3.25pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt;  BACKGROUND-COLOR: transparent">
                        <xsl:value-of select="@Name"/>
                    </span>
                </li>
                <li>
                    <strong>RuntimeID=</strong>
                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="@RuntimeId" xd:xctname="PlainText" xd:CtrlId="CTRL69" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: -3.25pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                        <xsl:value-of select="@RuntimeId"/>
                    </span>
                </li>
                <li>
                    <strong>Class Name=</strong>
                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="@ClassName" xd:xctname="PlainText" xd:CtrlId="CTRL69" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: -3.25pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                        <xsl:value-of select="@ClassName"/>
                    </span>
                </li>
                <li>
                    <strong>Automation Id=</strong>
                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="@AutomationId" xd:xctname="PlainText" xd:CtrlId="CTRL70" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: -3.25pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                        <xsl:value-of select="@AutomationId"/>
                    </span>
                </li>
                <li>
                    <strong>Localized Control Type=</strong>
                    <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="@LocalizedControlType" xd:xctname="PlainText" xd:CtrlId="CTRL71" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; MARGIN-BOTTOM: -3.25pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                        <xsl:value-of select="@LocalizedControlType"/>
                    </span>
                </li>
            </ul>
            <div>
                <xsl:apply-templates select="Path" mode="_37"/>
            </div>
        </div>
    </xsl:template>
    <xsl:template match="Comment" mode="_41">
        <div class="xdSection xdRepeating" title="" style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; MARGIN-BOTTOM: 6px; BORDER-LEFT: #c0c0c0 1pt solid; WIDTH: 100%; BORDER-BOTTOM: #c0c0c0 1pt solid" align="left" xd:xctname="choicetermrepeating" xd:CtrlId="CTRL24" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <div>
                <span class="xdTextBox" hideFocus="1" title="" tabIndex="-1" xd:binding="." xd:xctname="PlainText" xd:CtrlId="CTRL25" xd:disableEditing="yes" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                    <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                            <xsl:value-of select="xdFormatting:formatString(.,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:value-of select="." disable-output-escaping="yes"/>
                        </xsl:otherwise>
                    </xsl:choose>
                </span>
            </div>
        </div>
    </xsl:template>
    <xsl:template match="Exception" mode="_41">
        <div class="xdSection xdRepeating" title="" style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; MARGIN-BOTTOM: 6px; MARGIN-LEFT: 0px; BORDER-LEFT: #c0c0c0 1pt solid; WIDTH: 100%; MARGIN-RIGHT: 0px; BORDER-BOTTOM: #c0c0c0 1pt solid" align="left" xd:xctname="choicetermrepeating" xd:CtrlId="CTRL26" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
            <div>
                <font color="#ff0000">
                    <strong>!! Exception !!</strong>
                </font>
            </div>
            <div>
                <strong>Message:</strong>
            </div>
            <div>
                <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="Message" xd:xctname="PlainText" xd:CtrlId="CTRL30" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; FONT-WEIGHT: bold; OVERFLOW-X: visible; MARGIN-BOTTOM: -3.25pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                    <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                            <xsl:value-of select="xdFormatting:formatString(Message,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:value-of select="Message" disable-output-escaping="yes"/>
                        </xsl:otherwise>
                    </xsl:choose>
                </span>
            </div>
            <div> </div>
            <div>
                <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 100%; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse;" borderColor="buttontext" border="1">
                    <colgroup>
                        <col style="WIDTH: 160px"></col>
                        <col style="WIDTH: 100%"></col>
                    </colgroup>
                    <tbody vAlign="top">
                        <tr>
                            <td style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; PADDING-TOP: 1px">
                                <div>
                                    <font face="Verdana" size="2">Unexpected Exception:</font>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <font face="Verdana" size="2">
                                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="@Unexpected" xd:xctname="PlainText" xd:CtrlId="CTRL27">
                                            <xsl:attribute name="style">
                                                BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent;<xsl:choose>
                                                    <xsl:when test="@Unexpected = &quot;true&quot;">COLOR: #ff0000</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                            <xsl:value-of select="@Unexpected"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; PADDING-TOP: 1px">
                                <div>
                                    <font face="Verdana" size="2">Known Bug:</font>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <font face="Verdana" size="2">
                                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="@KnownBug" xd:xctname="PlainText" xd:CtrlId="CTRL28" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                            <xsl:value-of select="@KnownBug"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; PADDING-TOP: 1px">
                                <div>
                                    <font face="Verdana" size="2">Incorrect Configuration:</font>
                                </div>
                            </td>
                            <td>
                                <div>
                                    <font face="Verdana" size="2">
                                        <span class="xdTextBox" hideFocus="1" title="" tabIndex="0" xd:binding="@IncorrectConfiguration" xd:xctname="PlainText" xd:CtrlId="CTRL29" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
                                            <xsl:value-of select="@IncorrectConfiguration"/>
                                        </span>
                                    </font>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div>
                <strong/> 
            </div>
            <div>
                <strong>Stack Trace:</strong>
                <span class="xdTextBox" hideFocus="1" title="" tabIndex="-1" xd:binding="StackTrace" xd:xctname="PlainText" xd:CtrlId="CTRL31" xd:disableEditing="yes" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 100%; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
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
