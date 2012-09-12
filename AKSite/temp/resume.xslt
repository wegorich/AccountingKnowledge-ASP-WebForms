<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output encoding="Windows-1251" method="html" indent="yes"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Резюмэ</title>
				<META HTTP-EQUIV="Content-Type" content="text/html; charset=utf-8"/>
			</head>
			<body>
				<xsl:apply-templates/>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="Resume">
		<table style="border: 1px solid #E5E5E5;
    border-radius: 5px;
    -moz-border-radius: 5px;
    -khtml-border-radius: 5px;
    -webkit-border-radius: 5px;
    padding: 5px 15px;">
			<tbody>
				<tr>
					<td>
						<xsl:value-of select="Id"/>
					</td>
					<td>
						<xsl:value-of select="Title"/>
					</td>
					<td>
						<xsl:value-of select="Description"/>
					</td>
					<td>
						<xsl:value-of select="Date"/>
					</td>
				</tr>
				<tr>
				<td>
					<table>
						<tbody>
							<xsl:apply-templates select="Client"/>
						</tbody>
					</table>
					</td>
				</tr>
				<tr>
				<td>
					<table>
						<tbody>
							<xsl:apply-templates select="Fields/ResumeField"/>
						</tbody>
					</table>
					</td>
				</tr>
			</tbody>
		</table>
	</xsl:template>
	<xsl:template match="Client">
		<tr>
			<td>
				<xsl:value-of select="Id"/>
			</td>
			<td>
				<xsl:value-of select="Email"/>
			</td>
			<td>
				<xsl:value-of select="FirstName"/>
			</td>
			<td>
				<xsl:value-of select="SecondName"/>
			</td>
			<td>
				<xsl:value-of select="Login"/>
			</td>
			<td>
				<xsl:value-of select="Pass"/>
			</td>
			<td>
				<xsl:value-of select="BirthDay"/>
			</td>
			<td>
				<xsl:value-of select="PhoneNumber"/>
			</td>
			<td>
				<xsl:value-of select="Privilegy"/>
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="ResumeField">
		<tr>
			<td>
				<xsl:value-of select="FieldName"/>
			</td>
			<td>
				<table>
					<tbody>
						<xsl:apply-templates select="Theme/ResumeTheme"/>
					</tbody>
				</table>
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="ResumeTheme">
		<tr>
			<td>
				<xsl:value-of select="Id"/>
			</td>
			<td>
				<xsl:value-of select="SkillId"/>
			</td>
			<td>
				<xsl:value-of select="ResumeId"/>
			</td>
			<td>
				<xsl:value-of select="ThemeId"/>
			</td>
			<td>
				<xsl:value-of select="FieldName"/>
			</td>
			<td>
				<xsl:value-of select="SkillName"/>
			</td>
			<td>
				<xsl:value-of select="ThemeName"/>
			</td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
