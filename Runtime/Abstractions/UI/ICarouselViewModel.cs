using Lukomor.MVVM;

namespace com.ksgames.core.abstractions.ui
{
    public interface ICarouselViewModel: IViewModel
    {
        public string Caption { get;}
        void OnActionBtnClick();
    }
}