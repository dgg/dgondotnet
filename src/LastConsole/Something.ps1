<#
.SYNOPSIS
Does something
#>
[CmdletBinding()]
Param(
	<# where the something was done #>
	[Parameter(Mandatory=$True)]
	[string]$location,
	<# number of times something was done #>
	[Parameter(Mandatory=$False)]
	[int]$times = 1,
	<# include if the something was awesome #>
	[Parameter(Mandatory=$False)]
	[switch]$awesome
)

function DoSomething () {
	LoadLocalAssembly 'DgonDotNet.Blog.Samples.LastConsole.dll'
	
	$options = BuildOptions

	$out = [System.Console]::Out
	$command = New-Object DgonDotNet.Blog.Samples.LastConsole.ADoerOfSomething -ArgumentList $out
	$command.Do($options)
}

function LoadLocalAssembly ($theAssembly) {
	$current_location = resolve-path .
	$assembly = Join-Path $current_location $theAssembly
	$assembly = [System.Reflection.Assembly]::LoadFile($assembly)
}

function BuildOptions() {
	$options = New-Object DgonDotNet.Blog.Samples.LastConsole.OptionsForSomething
	$options.Awesome = $awesome
	$options.Location = $location
	$options.Times = $times
	return $options
}

function BuildCommand() {
}

DoSomething