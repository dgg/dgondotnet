<#
.SYNOPSIS
Does something else
#>
[CmdletBinding()]
Param(
	<# where the something else was done #>
	[Parameter(Mandatory=$True, HelpMessage="where the something else was done")]
	[string[]]$locations,
	<# include if the something was awesome #>
	[Parameter(Mandatory=$False)]
	[switch]$awesome
)

function DoSomething () {
	LoadLocalAssembly 'DgonDotNet.Blog.Samples.LastConsole.dll'
	
	$options = BuildOptions

	$out = [System.Console]::Out
	$command = New-Object DgonDotNet.Blog.Samples.LastConsole.ADoerOfSomethingElse -ArgumentList $out
	$command.Do($options)
}

function LoadLocalAssembly ($theAssembly) {
	$current_location = resolve-path .
	$assembly = Join-Path $current_location $theAssembly
	$assembly = [System.Reflection.Assembly]::LoadFile($assembly)
}

function BuildOptions() {
	$options = New-Object DgonDotNet.Blog.Samples.LastConsole.OptionsForSomethingElse
	$options.NotSoAwesome = !$awesome
	$options.Locations = $locations
	return $options
}

function BuildCommand() {
}

DoSomething