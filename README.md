# NT106 Lab 3 — Lập trình socket C#

Yêu cầu Windows và .NET 8 SDK. Mở solution bằng Visual Studio với workload **.NET desktop development**, hoặc chạy lệnh trong PowerShell tại thư mục repo.

| Bài theo đề PDF 2019 | Lệnh chạy | Cách demo |
|---|---|---|
| 1 — UDP | `dotnet run --project Bai01` | Mở Server, Listen trên một cổng. Mở Client, nhập `127.0.0.1`, cùng cổng và nội dung, rồi Send. |
| 2 — Telnet | `dotnet run --project Bai02` | Bấm Listen. Từ cửa sổ khác chạy `telnet 127.0.0.1 8080`, nhập tin nhắn và nhấn Enter. Bật Telnet Client trong Windows Features nếu chưa có lệnh. |
| 3 — TCP một client | `dotnet run --project Bai03` | Mở Server, bấm Listen, mở Client và lần lượt bấm Connect, Send, Disconnect. |
| 4 — TCP chat room | `dotnet run --project Bai04` | Mở Server, bấm Start. Mở hai cửa sổ Client với hai tên khác nhau, IP `127.0.0.1`, port `8085`. Để trống ô người nhận để gửi cho tất cả client còn lại. |

Khi nộp theo PDF 2019, chụp màn hình bốn bài ở trên và ghi lại các bước demo trong báo cáo.
