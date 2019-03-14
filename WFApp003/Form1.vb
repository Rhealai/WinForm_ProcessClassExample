Imports System.IO


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim Dir As String = "C:\"
        Directory.SetCurrentDirectory(Dir)
        TextBox1.Text = RunWinApplication()

        My.Settings.Conut += 1
        TextBox2.Text = My.Settings.Conut.ToString

    End Sub

    Private Function RunWinApplication() As String
        '實例一個Process類，啟動一個獨立p進程
        Dim p As Process = New Process()

        'Process類有一個StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：

        p.StartInfo.WorkingDirectory = "C:\"
        p.StartInfo.FileName = "run.bat"           '設定程序名

        p.StartInfo.UseShellExecute = False        '關閉Shell的使用
        p.StartInfo.RedirectStandardInput = True   '重定向標準輸入
        p.StartInfo.RedirectStandardOutput = True  '重定向標準輸出
        p.StartInfo.RedirectStandardError = True   '重定向錯誤輸出
        p.StartInfo.CreateNoWindow = True          '設置顯示窗口

        p.Start() '啟動
        Return p.StandardOutput.ReadToEnd()        '從輸出流取得命令執行結果

    End Function

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TextBox2.Text = My.Settings.Conut.ToString
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.Conut = 0
        TextBox2.Text = My.Settings.Conut.ToString
    End Sub
End Class
