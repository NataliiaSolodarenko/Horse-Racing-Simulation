# Horse-Racing-Simulation

<h3><b>📌 About the Project</b></h3>

Horse Racing Simulation is a Windows Forms (WinForms) application written in C#. It simulates a race between five horses, each represented by a progress bar running in its own thread. The race starts simultaneously using a barrier for synchronization, and the results are displayed in a table at the end.

<h3><b>🧩 Key Features</b></h3>

* Multithreaded Simulation: Each horse runs on a separate thread with randomized speed.
* Synchronized Start: All horses begin the race at the same time using a Barrier.
* Live UI Update: Progress bars show the live status of each horse.
* Race Cancellation: Press the button again to stop the race early.
* Result Display: Final standings are shown in a DataGridView upon race completion.
* Safe Exit Handling: Prevents the user from closing the window while the race is still in progress.

<h3><b>💡 Technologies Used</b></h3>

* C# (.NET Framework)
* Windows Forms (WinForms)
* System.Threading (Tasks, Barrier)
* Timers and Delays
* UI Controls: ProgressBar, Button, DataGridView, MessageBox

<h3><b>🗃 Project Structure</b></h3>

* Form1.cs: Main application logic, UI handling, and race execution.
* Program.cs: Application entry point.
* Designer.cs: UI layout and component declarations.

<h3><b>📷 UI Preview</b></h3>

[Demo video of the project](https://vimeo.com/1100356774?share=copy)

<h3><b>📖 How It Works</b></h3>

1. Click "Start" — The application launches five tasks, one per horse.
2. Synchronized Launch — All horses begin moving at the same time.
3. Randomized Movement — Each horse's speed is randomized every 500ms.
4. Live Progress — Progress bars update to reflect each horse’s advancement.
5. Final Results — When all horses finish, their results are sorted and displayed.
6. Stopping the Race — Pressing "Stop" halts all movement and prevents results from displaying.

<h3><b>🚀 Getting Started</b></h3>

1. Clone the repository or download the code.
2. Open the solution in Visual Studio.
3. Run the application.
4. Click Start to launch the race. Click Stop to cancel it.

<h3><b>📌 Notes</b></h3>

* Created as part of a practical exam task during the study of C#.
* The program demonstrates core concepts of threading and UI synchronization.

<h3><b>📬 Contact</b></h3>

Feel free to reach out for questions or collaborations:
* Developer: Nataliia  Solodarenko
* [LinkedIn](https://www.linkedin.com/in/nataliia-solodarenko-5272b0305/)
* Email: nataliiasolodarenko@gmail.com
