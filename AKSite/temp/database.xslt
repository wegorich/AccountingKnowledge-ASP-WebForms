<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output encoding="Windows-1251" method="html" indent="yes"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Темы</title>
				<META HTTP-EQUIV="Content-Type" content="text/html; charset=utf-8"/>
			</head>
			<body>
				<table>
					<tbody>
						<xsl:apply-templates/>
					</tbody>
				</table>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="Clients">
	<div><b>Пользователи:</b></div>
		<table style="border: 1px solid #c90093;
    border-radius: 5px;
    -moz-border-radius: 5px;
    -khtml-border-radius: 5px;
    -webkit-border-radius: 5px;
    padding: 5px 15px;">
			<tbody>
			<xsl:apply-templates select="Client"/>
			</tbody>
		</table>
	</xsl:template>
	
	<xsl:template match="Privilegies">
	<div><b>Привилегии:</b></div>
		<table style="border: 1px solid #5000c9;
    border-radius: 5px;
    -moz-border-radius: 5px;
    -khtml-border-radius: 5px;
    -webkit-border-radius: 5px;
    padding: 5px 15px;">
			<tbody>
			
			<xsl:apply-templates select="Privilegy"/>
			</tbody>
		</table>
	</xsl:template>
	
	<xsl:template match="Privilegy">
		<tr>
			<td>
				<xsl:value-of select="Id"/>
			</td>
			<td>
				<xsl:value-of select="Title"/>
			</td>
	</tr>
	</xsl:template>
	
	<xsl:template match="Fields">
	<div><b>Области знаний:</b></div>
		<table style="border: 1px solid #c90000;
    border-radius: 5px;
    -moz-border-radius: 5px;
    -khtml-border-radius: 5px;
    -webkit-border-radius: 5px;
    padding: 5px 15px;">
			<tbody>
			<xsl:apply-templates select="Field"/>
				
			</tbody>
		</table>
	</xsl:template>
	
	<xsl:template match="Field">
		<tr>
			<td>
				<xsl:value-of select="Id"/>
			</td>
			<td>
				<xsl:value-of select="Title"/>
			</td>
	</tr>
	</xsl:template>
	
	<xsl:template match="Themes">
		<div><b>Темы:</b></div>
		<table style="border: 1px solid #0000c9;
    border-radius: 5px;
    -moz-border-radius: 5px;
    -khtml-border-radius: 5px;
    -webkit-border-radius: 5px;
    padding: 5px 15px;">
			<tbody>
			<xsl:apply-templates select="Theme"/>
			</tbody>
		</table>
	</xsl:template>
	
	<xsl:template match="Theme">
		<tr>
			<td>
				<xsl:value-of select="Id"/>
			</td>
			<td>
				<xsl:value-of select="FieldId"/>
			</td>
			<td>
				<xsl:value-of select="GroupName"/>
			</td>
			<td>
				<xsl:value-of select="Title"/>
			</td>
	</tr>
	</xsl:template>
	
	<xsl:template match="Skills">
	<div><b>Навыки:</b></div>
		<table style="border: 1px solid #0093c9;
    border-radius: 5px;
    -moz-border-radius: 5px;
    -khtml-border-radius: 5px;
    -webkit-border-radius: 5px;
    padding: 5px 15px;">
	<tbody>	
		<xsl:apply-templates select="Skill"/>
	</tbody>
		</table>
	</xsl:template>
	
	<xsl:template match="Skill">
		<tr>
			<td>
				<xsl:value-of select="Id"/>
			</td>
			<td>
				<xsl:value-of select="GroupName"/>
			</td>
			<td>
				<xsl:value-of select="Title"/>
			</td>
	</tr>
	</xsl:template>

	
	<xsl:template match="SkillGroups">
	<div><b>Группы навыков:</b></div>
<table style="border: 1px solid #00c950;
    border-radius: 5px;
    -moz-border-radius: 5px;
    -khtml-border-radius: 5px;
    -webkit-border-radius: 5px;
    padding: 5px 15px;">
	<tbody>	
		<xsl:apply-templates select="SkillGroup"/>
	</tbody>
</table>
	</xsl:template>
	
	<xsl:template match="SkillGroup">
		<tr>
			<td>
				<xsl:value-of select="Id"/>
			</td>
			<td>
				<xsl:value-of select="Title"/>
			</td>
	</tr>
	</xsl:template>
	
	
	<xsl:template match="Resumes">
		<div><b>Резюме:</b></div>
		<table style="border: 1px solid #5c0f0f;
    border-radius: 5px;
    -moz-border-radius: 5px;
    -khtml-border-radius: 5px;
    -webkit-border-radius: 5px;
    padding: 5px 15px;">
			<tbody>
			<xsl:apply-templates select="Resume"/>
			</tbody>
		</table>
	</xsl:template>
	
	<xsl:template match="Resume">

				<tr>
				<td>
						
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
						</tbody>
				</table>
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
