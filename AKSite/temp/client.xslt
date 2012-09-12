<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output encoding="Windows-1251" method="html" indent="yes"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Пользователи</title>
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
</xsl:stylesheet>
