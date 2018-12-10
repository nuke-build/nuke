namespace Nuke.Common.Tooling.Paket

open Paket

[<AutoOpen>]
module internal Utility = 
    let isNotNull v = isNull v |> not

module PaketPackageResolver =         
    let private getPackageFolder(packageName: Domain.PackageName, groupName: Domain.GroupName) (dependenciesFile: string): string = 
        if isNotNull dependenciesFile then
            let dependencies = Dependencies(dependenciesFile) 
            let path = 
                dependencies
                    .GetLockFile()
                    .GetGroup(groupName)
                    .GetPackage(packageName)
                    .Folder dependencies.RootPath groupName
            path
        else
            null
    
    let private getFirstPackageFolderInAnyGroup (packageName: Domain.PackageName) (dependenciesFile: string): string =
        if isNotNull dependenciesFile then
            let dependencies = Dependencies(dependenciesFile) 
            let package = 
                dependencies
                    .GetLockFile()
                    .Groups
                    |> Seq.where (fun g -> Option.isSome <| g.Value.TryFind(packageName))
                    |> Seq.map (fun g -> (g.Value.GetPackage(packageName).Folder dependencies.RootPath g.Value.Name, g.Value.Name))
                    |> Seq.tryHead
            match package with
            | Some (folder, _) ->
                folder
            | None ->
                null
        else
            null
    
    let TryGetLocalInstalledPackageDirectoryInAnyGroup (packageName: string) (dependenciesFile: string): string =
        let package = Domain.PackageName(packageName)
        getFirstPackageFolderInAnyGroup package dependenciesFile

    let TryGetLocalInstalledPackageDirectoryInMainGroup (packageName: string) (dependenciesFile: string): string =
        let package = Domain.PackageName(packageName), Domain.GroupName("Main")
        getPackageFolder package dependenciesFile
    
    let TryGetLocalInstalledPackageDirectory (packageName: string) (groupName: string) (dependenciesFile: string): string = 
        let package = Domain.PackageName(packageName), Domain.GroupName(groupName)
        getPackageFolder package dependenciesFile