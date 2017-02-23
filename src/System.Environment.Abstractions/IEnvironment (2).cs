// <copyright file="IEnvironment.cs" company="Nate Barbettini">
// Copyright (c) 2016 Nate Barbettini
// </copyright>

namespace System
{
    public interface IEnvironment
    {
        /// <summary>
        /// Gets the command line for this process.
        /// </summary>
        /// <returns>
        /// A string containing command-line arguments.
        /// </returns>
        string CommandLine { get; }

        /// <summary>
        /// Gets or sets the fully qualified path of the current working directory.
        /// </summary>
        /// <returns>A string containing a directory path.</returns>
        /// <exception cref="ArgumentException">Attempted to set to an empty string ("").</exception>
        /// <exception cref="ArgumentNullException">Attempted to set to null.</exception>
        /// <exception cref="IO.IOException">An I/O error occurred.</exception>
        /// <exception cref="IO.DirectoryNotFoundException">Attempted to set a local path that cannot be found.</exception>
        /// <exception cref="Security.SecurityException">The caller does not have the appropriate permission.</exception>
        string CurrentDirectory { get; set; }

        int CurrentManagedThreadId { get; }

        /// <summary>
        /// Gets or sets the exit code of the process.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer containing the exit code.
        /// The default value is 0 (zero), which indicates that the process completed successfully.
        /// </returns>
        int ExitCode { get; set; }

        bool HasShutdownStarted { get; }
        //
        /// <summary>Determines whether the current operating system is a 64-bit operating system.</summary>
        //
        /// <returns>true if the operating system is 64-bit; otherwise, false.</returns>
        bool Is64BitOperatingSystem { get; }
        //
        /// <summary>Determines whether the current process is a 64-bit process.</summary>
        //
        /// <returns>true if the process is 64-bit; otherwise, false.</returns>
        bool Is64BitProcess { get; }
        //
        /// <summary>Gets the NetBIOS name of this local computer.</summary>
        //
        /// <returns>A string containing the name of this computer.</returns>
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     The name of this computer cannot be obtained.
        string MachineName { get; }
        string NewLine { get; }
        //
        /// <summary>Gets an System.OperatingSystem object that contains the current platform identifier</summary>
        //     and version number.
        //
        /// <returns>An object that contains the platform identifier and version number.</returns>
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     This property was unable to obtain the system version.-or- The obtained platform
        //     identifier is not a member of System.PlatformID
        OperatingSystem OSVersion { get; }
        int ProcessorCount { get; }
        string StackTrace { get; }
        //
        /// <summary>Gets the fully qualified path of the system directory.</summary>
        //
        /// <returns>A string containing a directory path.</returns>
        string SystemDirectory { get; }
        //
        /// <summary>Gets the number of bytes in the operating system's memory page.</summary>
        //
        /// <returns>The number of bytes in the system memory page.</returns>
        int SystemPageSize { get; }
        int TickCount { get; }
        //
        /// <summary>Gets the network domain name associated with the current user.</summary>
        //
        /// <returns>The network domain name associated with the current user.</returns>
        //
        // Exceptions:
        //   T:System.PlatformNotSupportedException:
        //     The operating system does not support retrieving the network domain name.
        //
        //   T:System.InvalidOperationException:
        //     The network domain name cannot be retrieved.
        string UserDomainName { get; }
        //
        /// <summary>Gets a value indicating whether the current process is running in user interactive
        //     mode.</summary>
        //
        /// <returns>true if the current process is running in user interactive mode; otherwise, false.</returns>
        bool UserInteractive { get; }
        //
        /// <summary>Gets the user name of the person who is currently logged on to the Windows operating
        //     system.</summary>
        //
        /// <returns>The user name of the person who is logged on to Windows.</returns>
        string UserName { get; }
        //
        /// <summary>Gets a System.Version object that describes the major, minor, build, and revision
        //     numbers of the common language runtime.</summary>
        //
        /// <returns>An object that displays the version of the common language runtime.</returns>
        Version Version { get; }
        //
        /// <summary>Gets the amount of physical memory mapped to the process context.</summary>
        //
        /// <returns>A 64-bit signed integer containing the number of bytes of physical memory mapped
        //     to the process context.</returns>
        long WorkingSet { get; }

        //
        /// <summary>Terminates this process and returns an exit code to the operating system.</summary>
        //
        // Parameters:
        //   exitCode:
        //     The exit code to return to the operating system. Use 0 (zero) to indicate that
        //     the process completed successfully.
        //
        // Exceptions:
        //   T:System.Security.SecurityException:
        //     The caller does not have sufficient security permission to perform this function.
        [SecuritySafeCritical]
        void Exit(int exitCode);
        [SecuritySafeCritical]
        string ExpandEnvironmentVariables(string name);
        [SecurityCritical]
        void FailFast(string message);
        [SecurityCritical]
        void FailFast(string message, Exception exception);
        //
        /// <summary>Returns a string array containing the command-line arguments for the current
        //     process.</summary>
        //
        /// <returns>An array of string where each element contains a command-line argument. The first
        //     element is the executable file name, and the following zero or more elements
        //     contain the remaining command-line arguments.</returns>
        //
        // Exceptions:
        //   T:System.NotSupportedException:
        //     The system does not support command-line arguments.
        [SecuritySafeCritical]
        string[] GetCommandLineArgs();
        [SecuritySafeCritical]
        string GetEnvironmentVariable(string variable);
        //
        /// <summary>Retrieves the value of an environment variable from the current process or from
        //     the Windows operating system registry key for the current user or local machine.</summary>
        //
        // Parameters:
        //   variable:
        //     The name of an environment variable.
        //
        //   target:
        //     One of the System.EnvironmentVariableTarget values.
        //
        /// <returns>The value of the environment variable specified by the variable and target parameters,
        //     or null if the environment variable is not found.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     variable is null.
        //
        //   T:System.ArgumentException:
        //     target is not a valid System.EnvironmentVariableTarget value.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission to perform this operation.
        [SecuritySafeCritical]
        string GetEnvironmentVariable(string variable, EnvironmentVariableTarget target);
        [SecuritySafeCritical]
        IDictionary GetEnvironmentVariables();
        //
        /// <summary>Retrieves all environment variable names and their values from the current process,
        //     or from the Windows operating system registry key for the current user or local
        //     machine.</summary>
        //
        // Parameters:
        //   target:
        //     One of the System.EnvironmentVariableTarget values.
        //
        /// <returns>A dictionary that contains all environment variable names and their values from
        //     the source specified by the target parameter; otherwise, an empty dictionary
        //     if no environment variables are found.</returns>
        //
        // Exceptions:
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission to perform this operation for
        //     the specified value of target.
        //
        //   T:System.ArgumentException:
        //     target contains an illegal value.
        [SecuritySafeCritical]
        IDictionary GetEnvironmentVariables(EnvironmentVariableTarget target);
        //
        /// <summary>Gets the path to the system special folder that is identified by the specified
        //     enumeration.</summary>
        //
        // Parameters:
        //   folder:
        //     An enumerated constant that identifies a system special folder.
        //
        /// <returns>The path to the specified system special folder, if that folder physically exists
        //     on your computer; otherwise, an empty string ("").A folder will not physically
        //     exist if the operating system did not create it, the existing folder was deleted,
        //     or the folder is a virtual directory, such as My Computer, which does not correspond
        //     to a physical path.</returns>
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     folder is not a member of System.Environment.SpecialFolder.
        //
        //   T:System.PlatformNotSupportedException:
        //     The current platform is not supported.
        [SecuritySafeCritical]
        string GetFolderPath(SpecialFolder folder);
        //
        /// <summary>Gets the path to the system special folder that is identified by the specified
        //     enumeration, and uses a specified option for accessing special folders.</summary>
        //
        // Parameters:
        //   folder:
        //     An enumerated constant that identifies a system special folder.
        //
        //   option:
        //     Specifies options to use for accessing a special folder.
        //
        /// <returns>The path to the specified system special folder, if that folder physically exists
        //     on your computer; otherwise, an empty string ("").A folder will not physically
        //     exist if the operating system did not create it, the existing folder was deleted,
        //     or the folder is a virtual directory, such as My Computer, which does not correspond
        //     to a physical path.</returns>
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     folder is not a member of System.Environment.SpecialFolder
        //
        //   T:System.PlatformNotSupportedException:
        //     System.PlatformNotSupportedException
        [SecuritySafeCritical]
        string GetFolderPath(SpecialFolder folder, SpecialFolderOption option);
        //
        /// <summary>Returns an array of string containing the names of the logical drives on the
        //     current computer.</summary>
        //
        /// <returns>An array of strings where each element contains the name of a logical drive.
        //     For example, if the computer's hard drive is the first logical drive, the first
        //     element returned is "C:\".</returns>
        //
        // Exceptions:
        //   T:System.IO.IOException:
        //     An I/O error occurs.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permissions.
        [SecuritySafeCritical]
        string[] GetLogicalDrives();
        [SecuritySafeCritical]
        void SetEnvironmentVariable(string variable, string value);
        //
        /// <summary>Creates, modifies, or deletes an environment variable stored in the current process
        //     or in the Windows operating system registry key reserved for the current user
        //     or local machine.</summary>
        //
        // Parameters:
        //   variable:
        //     The name of an environment variable.
        //
        //   value:
        //     A value to assign to variable.
        //
        //   target:
        //     One of the enumeration values that specifies the location of the environment
        //     variable.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     variable is null.
        //
        //   T:System.ArgumentException:
        //     variable contains a zero-length string, an initial hexadecimal zero character
        //     (0x00), or an equal sign ("="). -or-The length of variable is greater than or
        //     equal to 32,767 characters.-or-target is not a member of the System.EnvironmentVariableTarget
        //     enumeration. -or-target is System.EnvironmentVariableTarget.Machine or System.EnvironmentVariableTarget.User,
        //     and the length of variable is greater than or equal to 255.-or-target is System.EnvironmentVariableTarget.Process
        //     and the length of value is greater than or equal to 32,767 characters. -or-An
        //     error occurred during the execution of this operation.
        //
        //   T:System.Security.SecurityException:
        //     The caller does not have the required permission to perform this operation.
        [SecuritySafeCritical]
        void SetEnvironmentVariable(string variable, string value, EnvironmentVariableTarget target);

    }
}
