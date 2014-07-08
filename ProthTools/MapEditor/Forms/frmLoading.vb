
Public NotInheritable Class frmLoading

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).

    Private Sub frmLoading_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        ApplicationTitle.Text = CON_APPTITLE
        
        ' Version Information
        Version.Text = CON_APPVERSION

        'Copyright info
        Copyright.Text = CON_COPYRIGHT
    End Sub

End Class
