using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPApp.Structural
{
  public interface IFileSystem
  {

    public string FileName { get; init; }

  } // Folder ve File Nesnelerini türetmek için kullanacağız

  // Sub
  public class File : IFileSystem
  {
    public string FileName { get; init; }

    public File(string fileName)
    {
      FileName = fileName;
    }
  }

  // Composite Nesnesi
  public class Folder : IFileSystem
  {

    private List<IFileSystem> _fileSystem = new List<IFileSystem>();

    public IImmutableList<IFileSystem> FileSystems => _fileSystem.ToImmutableList();

    public string FileName { get; init; }

    public Folder(string fileName)
    {
      FileName = fileName;
    }

    public void Add(IFileSystem fileSystem)
    {
      // Folder and File Exist controlü , file ve folder oluşturma kontrolü Folder Add methodu üzerinden yönetilir.
      _fileSystem.Add(fileSystem);
    }



  }
}
