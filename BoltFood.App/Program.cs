using BoltFood.Service.Elaveler;
using BoltFood.Service.Services.Implementations;
using BoltFood.Service.Services.Interfaces;

Consol.MyWriteLine(" - - - - - - - - - - - - - - - - - - - - - - - -   Bolt Food'a xos gelmisiniz   - - - - - - - - - - - - - - - - - - - - ");


IMenuService menuService = new MenuService();

menuService.ShowMenuAsync();





