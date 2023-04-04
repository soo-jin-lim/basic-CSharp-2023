using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cs04_enums
{
    // TODO: SomeType의 인스턴스를 디버깅할 때 이 시각화 도우미를 표시하려면 SomeType의 정의에 다음을 추가합니다.
    // 
    //  [DebuggerVisualizer(typeof(Visualizer1))]
    //  [Serializable]
    //  public class SomeType
    //  {
    //   ...
    //  }
    // 
    /// <summary>
    /// SomeType의 시각화 도우미입니다.  
    /// </summary>
    public class Visualizer1 : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            if (windowService == null)
                throw new ArgumentNullException("windowService");
            if (objectProvider == null)
                throw new ArgumentNullException("objectProvider");

            // TODO: 시각화 도우미를 표시할 개체를 가져옵니다.
            //       시각화되는 개체의 형식에 objectProvider.GetObject()의 
            //       결과를 캐스트합니다.
            object data = (object)objectProvider.GetObject();

            // TODO: 개체의 뷰를 표시합니다.
            //       displayForm을 사용자 지정 폼 및 컨트롤로 대체합니다.
            using(Form displayForm = new Form())
            {
                displayForm.Text = data.ToString();
                windowService.ShowDialog(displayForm);
            }
        }

        // TODO: 시각화 도우미를 테스트하기 위해 다음을 테스트 코드에 추가합니다.
        // 
        //    Visualizer1.TestShowVisualizer(new SomeType());
        // 
        /// <summary>
        /// 시각화 도우미를 디버거 외부에서 호스팅하여 시각화 도우미를 테스트합니다.
        /// </summary>
        /// <param name="objectToVisualize">시각화 도우미에 표시할 개체입니다.</param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(Visualizer1));
            visualizerHost.ShowVisualizer();
        }
    }
}
