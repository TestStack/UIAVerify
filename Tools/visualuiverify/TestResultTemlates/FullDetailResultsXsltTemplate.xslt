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
        <div/>
        <div>
          <table class="xdRepeatingTable msoUcTable" title="" style="TABLE-LAYOUT: fixed; WIDTH: 750px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word; BORDER-BOTTOM-STYLE: none" border="1" xd:CtrlId="CTRL137">
            <colgroup>
              <col style="WIDTH: 373px"></col>
              <col style="WIDTH: 377px"></col>
            </colgroup>
            <tbody class="xdTableHeader">
              <tr style="MIN-HEIGHT: 32px">
                <td colSpan="2" style="PADDING-RIGHT: 1px; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; PADDING-TOP: 1px">
                  <div>
                    <strong>
                      <font size="3">Performed Tests: </font>
                      <span class="xdExpressionBox xdDataBindingUI" title="" xd:CtrlId="CTRL237" tabIndex="-1" xd:disableEditing="yes" xd:xctname="ExpressionBox" style="FONT-SIZE: small; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px">
                        <xsl:value-of select="count(Test)"/>
                      </span>
                    </strong>
                  </div>
                </td>
              </tr>
            </tbody>
            <tbody xd:xctname="RepeatingTable">
              <xsl:for-each select="Test">
                <tr>
                  <td style="BORDER-BOTTOM: #000000 3pt groove">
                    <div>
                      <div class="xdSection xdRepeating" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" xd:xctname="choicegrouprepeating" xd:ref="TestInfo">
                        <xsl:apply-templates select="TestInfo/Author|TestInfo/MethodInfo|TestInfo/AutomationElement" mode="_59"/>
                      </div>
                    </div>
                  </td>
                  <td style="BORDER-BOTTOM: #000000 3pt groove; BACKGROUND-COLOR: #fefab1">
                    <div>
                      <strong>Test Result:</strong>
                      <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL238" tabIndex="0" xd:xctname="PlainText" xd:binding="Result/@Status">
                        <xsl:attribute name="style">
                          BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; FONT-WEIGHT: bold; FONT-SIZE: small; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 200px; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent;<xsl:choose>
                            <xsl:when test="Result/@Status = &quot;Passed&quot;">COLOR: #008000</xsl:when>
                            <xsl:when test="Result/@Status = &quot;Failed&quot;">FONT-WEIGHT: bold; COLOR: #ff0000</xsl:when>
                            <xsl:when test="Result/@Status = &quot;UnexpectedError&quot;">COLOR: #ffffff; BACKGROUND-COLOR: #ff0000</xsl:when>
                          </xsl:choose>
                        </xsl:attribute>
                        <xsl:value-of select="Result/@Status"/>
                      </span>
                    </div>
                    <div> </div>
                    <div>
                      <strong>Messages:</strong>
                    </div>
                    <div>
                      <div class="xdSection xdRepeating" style="MARGIN-BOTTOM: 6px; WIDTH: 100%; HEIGHT: 348px; HEIGHT: auto" xd:xctname="choicegrouprepeating" xd:ref="Messages">
                        <xsl:apply-templates select="Messages/Comment|Messages/Exception" mode="_71"/>
                      </div>
                    </div>
                  </td>
                </tr>
              </xsl:for-each>
            </tbody>
          </table>
        </div>
        <div> </div>
      </body>
    </html>
  </xsl:template>
  <xsl:template match="Author" mode="_59">
    <div class="xdSection xdRepeating" title="" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" align="left" xd:CtrlId="CTRL139" xd:xctname="choicetermrepeating" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <div>
        <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 348px; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
          <colgroup>
            <col style="WIDTH: 105px"></col>
            <col style="WIDTH: 243px"></col>
          </colgroup>
          <tbody vAlign="top">
            <tr style="MIN-HEIGHT: 17px">
              <td colSpan="2" style="BORDER-RIGHT: #000000 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #000000 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #000000 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1pt solid">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Name:</strong>
                    <xsl:value-of select="../Name" disable-output-escaping="yes"/>
                  </font>
                </div>
              </td>
            </tr>
            <tr style="MIN-HEIGHT: 21px">
              <td style="BORDER-RIGHT: #000000 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #000000 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #000000 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1pt solid">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Priority:</strong>
                  </font>
                </div>
              </td>
              <td style="BORDER-RIGHT: #000000 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #000000 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #000000 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1pt solid">
                <div>
                  <font face="Verdana" size="2">
                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL142" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="../Priority" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 100%; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                      <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                          <xsl:value-of select="xdFormatting:formatString(../Priority,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="../Priority" disable-output-escaping="yes"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </span>
                  </font>
                </div>
              </td>
            </tr>
            <tr>
              <td style="BORDER-RIGHT: #000000 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #000000 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #000000 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1pt solid">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Author:</strong>
                  </font>
                </div>
              </td>
              <td style="BORDER-RIGHT: #000000 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #000000 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #000000 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1pt solid">
                <div>
                  <font face="Verdana" size="2">
                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL140" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="." style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 100%; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                      <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                          <xsl:value-of select="xdFormatting:formatString(.,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="." disable-output-escaping="yes"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </span>
                  </font>
                </div>
              </td>
            </tr>
            <tr style="MIN-HEIGHT: 21px">
              <td style="BORDER-RIGHT: #000000 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #000000 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: top; BORDER-LEFT: #000000 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1pt solid">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Summary:</strong>
                  </font>
                </div>
              </td>
              <td style="BORDER-RIGHT: #000000 1pt solid; PADDING-RIGHT: 1px; BORDER-TOP: #000000 1pt solid; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #000000 1pt solid; PADDING-TOP: 1px; BORDER-BOTTOM: #000000 1pt solid">
                <div>
                  <font face="Verdana" size="2">
                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL146" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="../Summary" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 100%; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                      <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                          <xsl:value-of select="xdFormatting:formatString(../Summary,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="../Summary" disable-output-escaping="yes"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </span>
                  </font>
                </div>
              </td>
            </tr>
            <tr style="MIN-HEIGHT: 18px">
              <td colSpan="2" style="BORDER-RIGHT: #000000 1pt solid; BORDER-TOP: #000000 1pt solid; BORDER-LEFT: #000000 1pt solid; BORDER-BOTTOM: #000000 1pt solid">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Description:</strong>
                  </font>
                </div>
                <div>
                  <span class="xdRepeating" title="" style="MARGIN-BOTTOM: 1px; WIDTH: 100%" xd:xctname="NumberedList">
                    <ol style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px; LIST-STYLE-TYPE: decimal">
                      <xsl:for-each select="../Description">
                        <li>
                          <span class="xdListItem" hideFocus="1" xd:CtrlId="CTRL175" tabIndex="0" xd:xctname="ListItem_Plain" xd:binding="." style="WIDTH: 100%">
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
    </div>
  </xsl:template>
  <xsl:template match="MethodInfo" mode="_59">
    <div class="xdSection xdRepeating" title="" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" align="left" xd:CtrlId="CTRL153" xd:xctname="choicetermrepeating" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <div>
        <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 348px; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
          <colgroup>
            <col style="WIDTH: 348px"></col>
          </colgroup>
          <tbody vAlign="top">
            <tr style="MIN-HEIGHT: 21px">
              <td style="BORDER-RIGHT: #969696 1pt; BORDER-TOP: #969696 1pt; BORDER-LEFT: #969696 1pt; BORDER-BOTTOM: #969696 1pt">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Assembly:</strong>
                  </font>
                </div>
                <div>
                  <font face="Verdana" size="2">
                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL154" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="AssemblyFile" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 100%; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                      <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                          <xsl:value-of select="xdFormatting:formatString(AssemblyFile,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="AssemblyFile" disable-output-escaping="yes"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </span>
                  </font>
                </div>
              </td>
            </tr>
            <tr style="MIN-HEIGHT: 21px">
              <td style="BORDER-RIGHT: #969696 1pt; BORDER-TOP: #969696 1pt; BORDER-LEFT: #969696 1pt; BORDER-BOTTOM: #969696 1pt">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Class:</strong>
                  </font>
                </div>
                <div>
                  <font face="Verdana" size="2">
                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL155" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="Class" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 100%; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                      <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                          <xsl:value-of select="xdFormatting:formatString(Class,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="Class" disable-output-escaping="yes"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </span>
                  </font>
                </div>
              </td>
            </tr>
            <tr style="MIN-HEIGHT: 22px">
              <td style="BORDER-RIGHT: #969696 1pt; BORDER-TOP: #969696 1pt; BORDER-LEFT: #969696 1pt; BORDER-BOTTOM: #969696 1pt">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Method:</strong>
                  </font>
                </div>
                <div>
                  <font face="Verdana" size="2">
                    <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL156" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="Method" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 100%; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                      <xsl:choose>
                        <xsl:when test="function-available('xdFormatting:formatString')">
                          <xsl:value-of select="xdFormatting:formatString(Method,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="Method" disable-output-escaping="yes"/>
                        </xsl:otherwise>
                      </xsl:choose>
                    </span>
                  </font>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </xsl:template>
  <xsl:template match="AutomationElement" mode="_59">
    <div class="xdSection xdRepeating" title="" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" align="left" xd:CtrlId="CTRL157" xd:xctname="choicetermrepeating" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <div>
        <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 348px; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
          <colgroup>
            <col style="WIDTH: 348px"></col>
          </colgroup>
          <tbody vAlign="top">
            <tr>
              <td style="BORDER-RIGHT: #969696 1pt dashed; BORDER-TOP: #969696 1pt dashed; BORDER-LEFT: #969696 1pt dashed; BORDER-BOTTOM: #969696 1pt dashed">
                <div>
                  <font face="Verdana" size="2">
                    <strong>Automation Element</strong>
                  </font>
                </div>
              </td>
            </tr>
            <tr style="MIN-HEIGHT: 234px">
              <td style="BORDER-RIGHT: #969696 1pt dashed; BORDER-TOP: #969696 1pt dashed; BORDER-LEFT: #969696 1pt dashed; BORDER-BOTTOM: #969696 1pt dashed">
                <div>
                  <strong>RuntimeId</strong>: <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL158" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="@ElementRuntimeId" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 130px; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                    <xsl:choose>
                      <xsl:when test="function-available('xdFormatting:formatString')">
                        <xsl:value-of select="xdFormatting:formatString(@ElementRuntimeId,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select="@ElementRuntimeId" disable-output-escaping="yes"/>
                      </xsl:otherwise>
                    </xsl:choose>
                  </span>
                </div>
                <div> </div>
                <div>Path to Element:</div>
                <div>
                  <xsl:apply-templates select="ElementPath/Path" mode="_88"/>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </xsl:template>
  <xsl:template match="Path" mode="_88">
    <div class="xdSection xdRepeating" title="" style="MARGIN-BOTTOM: 6px; WIDTH: 100%" align="left" xd:CtrlId="CTRL232" xd:xctname="Section" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <div>
        <em>Element:</em>
      </div>
      <ul style="MARGIN-TOP: 0px; MARGIN-BOTTOM: 0px" type="disc">
        <li>
          <strong>Name=</strong>
          <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL236" tabIndex="0" xd:xctname="PlainText" xd:binding="@Name" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
            <xsl:value-of select="@Name"/>
          </span>
        </li>
        <li>
          <strong>Runtime ID=</strong>
          <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL237" tabIndex="0" xd:xctname="PlainText" xd:binding="@RuntimeId" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
            <xsl:value-of select="@RuntimeId"/>
          </span>
        </li>
        <li>
          <strong>Class Name=</strong>
          <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL233" tabIndex="0" xd:xctname="PlainText" xd:binding="@ClassName" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
            <xsl:value-of select="@ClassName"/>
          </span>
        </li>
        <li>
          <strong>Automation Id=</strong>
          <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL234" tabIndex="0" xd:xctname="PlainText" xd:binding="@AutomationId" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
            <xsl:value-of select="@AutomationId"/>
          </span>
        </li>
        <li>
          <strong>Localized Control Type=</strong>
          <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL235" tabIndex="0" xd:xctname="PlainText" xd:binding="@LocalizedControlType" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; BACKGROUND-COLOR: transparent">
            <xsl:value-of select="@LocalizedControlType"/>
          </span>
        </li>
      </ul>
      <div>
        <xsl:apply-templates select="Path" mode="_88"/>
      </div>
    </div>
  </xsl:template>
  <xsl:template match="Comment" mode="_71">
    <div class="xdSection xdRepeating" title="" style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; MARGIN-BOTTOM: 6px; MARGIN-LEFT: 1px; BORDER-LEFT: #c0c0c0 1pt solid; WIDTH: 100%; MARGIN-RIGHT: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid" align="left" xd:CtrlId="CTRL165" xd:xctname="choicetermrepeating" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <div>
        <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL166" tabIndex="0" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="." style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
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
  <xsl:template match="Exception" mode="_71">
    <div class="xdSection xdRepeating" title="" style="BORDER-RIGHT: #c0c0c0 1pt solid; BORDER-TOP: #c0c0c0 1pt solid; MARGIN-BOTTOM: 6px; MARGIN-LEFT: 1px; BORDER-LEFT: #c0c0c0 1pt solid; WIDTH: 359px; MARGIN-RIGHT: 1px; BORDER-BOTTOM: #c0c0c0 1pt solid" align="left" xd:CtrlId="CTRL167" xd:xctname="choicetermrepeating" tabIndex="-1" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <div>
        <strong>Message:</strong>
      </div>
      <div>
        <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL171" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="Message" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; FONT-WEIGHT: bold; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 345px; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: #ff8080; WORD-WRAP: break-word">
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
        <strong>Failure Info</strong>
      </div>
      <div>
        <table class="xdLayout" style="BORDER-RIGHT: medium none; TABLE-LAYOUT: fixed; BORDER-TOP: medium none; BORDER-LEFT: medium none; WIDTH: 346px; BORDER-BOTTOM: medium none; BORDER-COLLAPSE: collapse; WORD-WRAP: break-word" borderColor="buttontext" border="1">
          <colgroup>
            <col style="WIDTH: 157px"></col>
            <col style="WIDTH: 189px"></col>
          </colgroup>
          <tbody vAlign="top">
            <tr>
              <td style="BORDER-RIGHT: #969696 1pt dashed; PADDING-RIGHT: 1px; BORDER-TOP: #969696 1pt dashed; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #969696 1pt dashed; PADDING-TOP: 1px; BORDER-BOTTOM: #969696 1pt dashed; BACKGROUND-COLOR: #ff8080">
                <div>
                  <font face="Verdana" size="2">Unexpected Exception:</font>
                </div>
              </td>
              <td style="BORDER-RIGHT: #969696 1pt dashed; PADDING-RIGHT: 1px; BORDER-TOP: #969696 1pt dashed; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #969696 1pt dashed; PADDING-TOP: 1px; BORDER-BOTTOM: #969696 1pt dashed; BACKGROUND-COLOR: #ff8080">
                <div>
                  <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL168" tabIndex="0" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="@Unexpected">
                    <xsl:attribute name="style">
                      BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; MARGIN-BOTTOM: 0pt; PADDING-BOTTOM: 0px; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word;<xsl:choose>
                        <xsl:when test="@Unexpected = &quot;true&quot;">COLOR: #ff0000</xsl:when>
                      </xsl:choose>
                    </xsl:attribute>
                    <xsl:choose>
                      <xsl:when test="function-available('xdFormatting:formatString')">
                        <xsl:value-of select="xdFormatting:formatString(@Unexpected,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select="@Unexpected" disable-output-escaping="yes"/>
                      </xsl:otherwise>
                    </xsl:choose>
                  </span>
                </div>
              </td>
            </tr>
            <tr>
              <td style="BORDER-RIGHT: #969696 1pt dashed; PADDING-RIGHT: 1px; BORDER-TOP: #969696 1pt dashed; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #969696 1pt dashed; PADDING-TOP: 1px; BORDER-BOTTOM: #969696 1pt dashed; BACKGROUND-COLOR: #ff8080">
                <div>
                  <font face="Verdana" size="2">Known Bug:</font>
                </div>
              </td>
              <td style="BORDER-RIGHT: #969696 1pt dashed; PADDING-RIGHT: 1px; BORDER-TOP: #969696 1pt dashed; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #969696 1pt dashed; PADDING-TOP: 1px; BORDER-BOTTOM: #969696 1pt dashed; BACKGROUND-COLOR: #ff8080">
                <div>
                  <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL169" tabIndex="0" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="@KnownBug" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                    <xsl:choose>
                      <xsl:when test="function-available('xdFormatting:formatString')">
                        <xsl:value-of select="xdFormatting:formatString(@KnownBug,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select="@KnownBug" disable-output-escaping="yes"/>
                      </xsl:otherwise>
                    </xsl:choose>
                  </span>
                </div>
              </td>
            </tr>
            <tr>
              <td style="BORDER-RIGHT: #969696 1pt dashed; PADDING-RIGHT: 1px; BORDER-TOP: #969696 1pt dashed; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #969696 1pt dashed; PADDING-TOP: 1px; BORDER-BOTTOM: #969696 1pt dashed; BACKGROUND-COLOR: #ff8080">
                <div>
                  <font face="Verdana" size="2">Incorrect Configuration:</font>
                </div>
              </td>
              <td style="BORDER-RIGHT: #969696 1pt dashed; PADDING-RIGHT: 1px; BORDER-TOP: #969696 1pt dashed; PADDING-LEFT: 1px; PADDING-BOTTOM: 1px; VERTICAL-ALIGN: middle; BORDER-LEFT: #969696 1pt dashed; PADDING-TOP: 1px; BORDER-BOTTOM: #969696 1pt dashed; BACKGROUND-COLOR: #ff8080">
                <div>
                  <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL170" tabIndex="0" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="@IncorrectConfiguration" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: visible; OVERFLOW-X: visible; BORDER-LEFT: #dcdcdc 1pt; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; BACKGROUND-COLOR: transparent; WORD-WRAP: break-word">
                    <xsl:choose>
                      <xsl:when test="function-available('xdFormatting:formatString')">
                        <xsl:value-of select="xdFormatting:formatString(@IncorrectConfiguration,&quot;string&quot;,&quot;plainMultiline&quot;)" disable-output-escaping="yes"/>
                      </xsl:when>
                      <xsl:otherwise>
                        <xsl:value-of select="@IncorrectConfiguration" disable-output-escaping="yes"/>
                      </xsl:otherwise>
                    </xsl:choose>
                  </span>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <div> </div>
      <div>
        <strong>Stack Trace:</strong>
      </div>
      <div>
        <span class="xdTextBox" hideFocus="1" title="" xd:CtrlId="CTRL172" tabIndex="-1" xd:disableEditing="yes" xd:xctname="PlainText" xd:datafmt="&quot;string&quot;,&quot;plainMultiline&quot;" xd:binding="StackTrace" style="BORDER-RIGHT: #dcdcdc 1pt; BORDER-TOP: #dcdcdc 1pt; OVERFLOW-Y: scroll; OVERFLOW-X: scroll; BORDER-LEFT: #dcdcdc 1pt; WIDTH: 345px; BORDER-BOTTOM: #dcdcdc 1pt; WHITE-SPACE: normal; HEIGHT: 97px; BACKGROUND-COLOR: #ff8080; WORD-WRAP: break-word">
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
