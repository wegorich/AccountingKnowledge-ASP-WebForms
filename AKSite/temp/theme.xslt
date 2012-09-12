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
</xsl:stylesheet>
