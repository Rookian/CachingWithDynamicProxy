// Type: System.IO.StringWriter
// Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\mscorlib.dll

using System;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace System.IO
{
  /// <summary>
  /// Implements a <see cref="T:System.IO.TextWriter"/> for writing information to a string. The information is stored in an underlying <see cref="T:System.Text.StringBuilder"/>.
  /// </summary>
  /// <filterpriority>2</filterpriority>
  [ComVisible(true)]
  [Serializable]
  public class StringWriter : TextWriter
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.IO.StringWriter"/> class.
    /// </summary>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public StringWriter();
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.IO.StringWriter"/> class with the specified format control.
    /// </summary>
    /// <param name="formatProvider">An <see cref="T:System.IFormatProvider"/> object that controls formatting. </param>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public StringWriter(IFormatProvider formatProvider);
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.IO.StringWriter"/> class that writes to the specified <see cref="T:System.Text.StringBuilder"/>.
    /// </summary>
    /// <param name="sb">The StringBuilder to write to. </param><exception cref="T:System.ArgumentNullException"><paramref name="sb"/> is null. </exception>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public StringWriter(StringBuilder sb);
    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.IO.StringWriter"/> class that writes to the specified <see cref="T:System.Text.StringBuilder"/> and has the specified format provider.
    /// </summary>
    /// <param name="sb">The StringBuilder to write to. </param><param name="formatProvider">An <see cref="T:System.IFormatProvider"/> object that controls formatting. </param><exception cref="T:System.ArgumentNullException"><paramref name="sb"/> is null. </exception>
    public StringWriter(StringBuilder sb, IFormatProvider formatProvider);
    /// <summary>
    /// Closes the current <see cref="T:System.IO.StringWriter"/> and the underlying stream.
    /// </summary>
    /// <filterpriority>1</filterpriority>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public override void Close();
    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:System.IO.StringWriter"/> and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    protected override void Dispose(bool disposing);
    /// <summary>
    /// Returns the underlying <see cref="T:System.Text.StringBuilder"/>.
    /// </summary>
    /// 
    /// <returns>
    /// The underlying StringBuilder.
    /// </returns>
    /// <filterpriority>2</filterpriority>
    public virtual StringBuilder GetStringBuilder();
    /// <summary>
    /// Writes a character to this instance of the StringWriter.
    /// </summary>
    /// <param name="value">The character to write. </param><exception cref="T:System.ObjectDisposedException">The writer is closed. </exception><filterpriority>2</filterpriority>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public override void Write(char value);
    /// <summary>
    /// Writes the specified region of a character array to this instance of the StringWriter.
    /// </summary>
    /// <param name="buffer">The character array to read data from. </param><param name="index">The index at which to begin reading from <paramref name="buffer"/>. </param><param name="count">The maximum number of characters to write. </param><exception cref="T:System.ArgumentNullException"><paramref name="buffer"/> is null. </exception><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> or <paramref name="count"/> is negative. </exception><exception cref="T:System.ArgumentException">(<paramref name="index"/> + <paramref name="count"/>)&gt; <paramref name="buffer"/>. Length. </exception><exception cref="T:System.ObjectDisposedException">The writer is closed. </exception><filterpriority>2</filterpriority>
    public override void Write(char[] buffer, int index, int count);
    /// <summary>
    /// Writes a string to this instance of the StringWriter.
    /// </summary>
    /// <param name="value">The string to write. </param><exception cref="T:System.ObjectDisposedException">The writer is closed. </exception><filterpriority>2</filterpriority>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public override void Write(string value);
    [ComVisible(false)]
    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public override Task WriteAsync(char value);
    [ComVisible(false)]
    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public override Task WriteAsync(string value);
    [ComVisible(false)]
    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public override Task WriteAsync(char[] buffer, int index, int count);
    [ComVisible(false)]
    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public override Task WriteLineAsync(char value);
    [ComVisible(false)]
    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public override Task WriteLineAsync(string value);
    [ComVisible(false)]
    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public override Task WriteLineAsync(char[] buffer, int index, int count);
    [ComVisible(false)]
    [HostProtection(SecurityAction.LinkDemand, ExternalThreading = true)]
    public override Task FlushAsync();
    /// <summary>
    /// Returns a string containing the characters written to the current StringWriter so far.
    /// </summary>
    /// 
    /// <returns>
    /// The string containing the characters written to the current StringWriter.
    /// </returns>
    /// <filterpriority>2</filterpriority>
    [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
    public override string ToString();
    /// <summary>
    /// Gets the <see cref="T:System.Text.Encoding"/> in which the output is written.
    /// </summary>
    /// 
    /// <returns>
    /// The Encoding in which the output is written.
    /// </returns>
    /// <filterpriority>1</filterpriority>
    public override Encoding Encoding { [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] get; }
  }
}
