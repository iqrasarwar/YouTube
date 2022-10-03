class Widget
{
   public:
   Widget()
   {

   }
   ~Widget()
   {
      cout<<"des called"<<endl;
   }
   Widget(const Widget& w)
   {
      cout<<"copy cons called"<<endl;
   }
   //Constructors and destructors exist here...

}
   Widget f(Widget u)
   {
      Widget v(u);
      Widget w = v;
      return w;
   }
int main()
{
   Widget x;
   Widget y = f(f(x));
}
