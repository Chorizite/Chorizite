// The module 'vscode' contains the VS Code extensibility API
// Import the module and reference it with the alias vscode in your code below
import * as vscode from 'vscode';
import { GetStringRegKey } from '@vscode/windows-registry'
const extensionId = "Chorizite.chorizite-scripting" // this id is case sensitive


function setExternalLibrary(folder: string, enable: boolean) {
	const folderPath = folder
	const config = vscode.workspace.getConfiguration("Lua")
	const library: string[] | undefined = config.get("workspace.library")

	if (library) {
		// remove any older versions of our path e.g. "publisher.name-0.0.1"
		for (let i = library.length-1; i >= 0; i--) {
			const el = library[i]
			const isSelfExtension = el.indexOf(extensionId) > -1 || el.indexOf(extensionId.toLowerCase()) > -1
			if (isSelfExtension || el.indexOf("utilitybelt.ubscript-lua") > -1) {
				library.splice(i, 1)
			}
		}
		const index = library.indexOf(folderPath)
		if (enable) {
			if (index == -1) {
				library.push(folderPath)
			}
		}
		else {
			if (index > -1) {
				library.splice(index, 1)
			}
		}

		console.log("LIBRARIES", library)

		config.update("workspace.library", library, true)
	}
}

// This method is called when your extension is activated
export function activate(context: vscode.ExtensionContext) {
	let chorizitePath : string | undefined = "";
	try {
		chorizitePath = GetStringRegKey('HKEY_LOCAL_MACHINE', 'SOFTWARE\\Thrungus\\Chorizite', '');
	} catch {}
	
	if (!chorizitePath) {
		try {
			chorizitePath = GetStringRegKey('HKEY_LOCAL_MACHINE', 'SOFTWARE\\WOW6432Node\\Thrungus\\Chorizite', '');
		} catch {}
	}
	
	if (!chorizitePath) {
		chorizitePath = "C:\\Games\\Chorizite\\"
	}
	
	if (!chorizitePath.endsWith("\\")) chorizitePath = chorizitePath + "\\"
	chorizitePath = chorizitePath + "Lua\\defs"

	console.log("Chorizite Path: ", chorizitePath);

	// Use the console to output diagnostic information (console.log) and errors (console.error)
	// This line of code will only be executed once when your extension is activated
	setExternalLibrary(chorizitePath, true)
}

// This method is called when your extension is deactivated
export function deactivate() {}
