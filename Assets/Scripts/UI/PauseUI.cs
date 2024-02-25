using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Yuki
{
    public class PauseUI : UIManager
    {
        public void QuitGameplay()
        {
            SceneManager.LoadScene(0);
        }
    }
}
