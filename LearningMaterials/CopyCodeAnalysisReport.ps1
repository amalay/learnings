<# ------------------------------------------------------------------------
# NAME: CopyCodeAnalysisReport.ps1
# AUTHOR: Devraj Goswami, Microsoft
# DATE: 12/02/2016
#
# KEYWORDS: Code Analysis, File Copy
#
# COMMENTS: This script copies all the code analysis log files to a common directory.
#
# ------------------------------------------------------------------------#>
Param(  [parameter(Mandatory=$true)]
        $source = "",
        [parameter(Mandatory=$true)]
        $destination = ""       
     )

if(Test-Path $source)
{
    if(-Not (Test-Path $destination))
    {
        mkdir $destination -Force;
        Write-Output "Created Directory $destination"
    }
	Remove-Item -Path $destination\*.* -Recurse -Force;
    $files = ls -Path $source -Filter *.CodeAnalysisLog.xml -Recurse
    foreach($file in $files)
    {
        if(Test-Path $file.FullName)
        {
            Copy-Item $file.FullName -Destination $destination
            #Remove-Item $file.FullName
            Write-Output "Moved $file.Name"
        }
    }
}
else
{
    Write-Output "Source does not exist!"
}