using SG_MAUI_RamSerDav_.MVVM.Models;
using SG_MAUI_RamSerDav_.Repositories;

namespace SG_MAUI_RamSerDav_
{
    public partial class AppShell : Shell
    {
        public static BaseRepository<Usuario> UsuarioRepo { get; private set; }
        public AppShell(BaseRepository<Usuario> usuRepo)
        {   
            InitializeComponent();
            UsuarioRepo = usuRepo;
        }
    }
}
