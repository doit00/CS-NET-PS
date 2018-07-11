using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommand
{
    [Cmdlet(VerbsCommon.Get,"DateTimeInfo")]
    public class DemoCommand: Cmdlet
    {
        [Parameter(Mandatory =false,ParameterSetName ="FormatSet",ValueFromPipeline =true)]
        public string Format { get; set; }
        protected override void ProcessRecord()
        {
            if (Format != null && Format.Length > 0)
            {
                WriteObject(DateTime.Today.ToString(Format));
            }
            else
            {
                WriteObject(DateTime.Today);
            }
        }
    }

    [Cmdlet(VerbsCommon.Get,"Max")]
    public class MaxCommand : Cmdlet
    {
        List<int> ints = new List<int>();

        [Parameter(ValueFromPipeline =true)]
        public int Number { get; set; }
        protected override void ProcessRecord()
        {
            ints.Add(Number);
        }

        protected override void EndProcessing()
        {
            WriteObject(ints.Max());
        }
    }

    [Cmdlet(VerbsCommon.Get, "Sum")]
    public class SumCommand : Cmdlet
    {
        int sum = 0;

        [Parameter(ValueFromPipeline = true)]
        public int Number { get; set; }
        protected override void ProcessRecord()
        {
            try
            {
                checked
                {
                    sum += Number;
                }
            }
            catch (OverflowException oe)
            {
                WriteError(new ErrorRecord(
                    oe, "int32 overflow exception", ErrorCategory.InvalidOperation, Number));
                
            }
            catch(Exception se)
            {
                WriteError(new ErrorRecord(
                    se, "System Exception", ErrorCategory.InvalidOperation, Number));
            }
           
        }

        protected override void EndProcessing()
        {
            WriteObject(sum);
        }
    }
}
