using System.Text;

namespace ChatGPTForCsharpDevelopers._2_documentation;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public Customer(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }

    /// <summary>
    /// <para>Generates a full name string based on the provided parameters.</para>
    /// <list type="bullet">
    /// <item><description><b>includeTitle:</b> A <i>bool</i> that determines whether to include the title in the full name. Default is <i>false</i>.</description></item>
    /// <item><description><b>title:</b> A <i>string</i> value representing the title to be included in the full name, if <i>includeTitle</i> is <i>true</i>.</description></item>
    /// <item><description><b>includeSuffix:</b> A <i>bool</i> that determines whether to include the suffix in the full name. Default is <i>false</i>.</description></item>
    /// <item><description><b>suffix:</b> A <i>string</i> value representing the suffix to be included in the full name, if <i>includeSuffix</i> is <i>true</i>.</description></item>
    /// </list>
    /// <returns>Returns a <i>string</i> representing the full name generated.</returns>
    /// </summary>
    public string GetFullName(bool includeTitle = false, string title = "", bool includeSuffix = false, string suffix = "")
    {
        var fullName = new StringBuilder();

        if (includeTitle && !string.IsNullOrWhiteSpace(title))
        {
            fullName.Append(title);
            fullName.Append(" ");
        }

        fullName.Append(FirstName);
        fullName.Append(" ");
        fullName.Append(LastName);

        if (includeSuffix && !string.IsNullOrWhiteSpace(suffix))
        {
            fullName.Append(", ");
            fullName.Append(suffix);
        }

        return fullName.ToString();
    }


    public bool IsEmailValid()
    {
        try
        {
            var mailAddress = new System.Net.Mail.MailAddress(Email);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
