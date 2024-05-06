namespace PracticandoConLINQ2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Mostrar en consola los 3 libros con más ventas.
            List<Book> allBooks = Book.Books();
            var topSellingBooks = allBooks
                                  .OrderByDescending(b => b.Sales)
                                  .Take(3);

            foreach (var book in topSellingBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Sales: {book.Sales} million");
            }


            // Mostrar en consola los 3 libros con menos ventas.

            var top3menosVentas = allBooks.OrderBy(b => b.Sales).Take(3);

            foreach (var book in top3menosVentas)
            {
                Console.WriteLine($"Title: {book.Title}, Sales: {book.Sales} million");
            }


            // Mostrar en consola el autor con más libros publicados.
            List<Author> allAuthors = Author.Authors();

            // Contar libros por autor
            var authorBookCounts = allBooks
                .GroupBy(b => b.AuthorId) // Agrupa los libros por el ID del autor
                .Select(group => new
                {
                    AuthorId = group.Key,
                    BookCount = group.Count() // Cuenta los libros para cada autor
                })
                .OrderByDescending(x => x.BookCount) // Ordena por la cuenta de libros de mayor a menor
                .FirstOrDefault(); // Toma el primero que será el que tiene más libros

            if (authorBookCounts != null)
            {
                // Buscar el autor por ID
                var topAuthor = allAuthors.FirstOrDefault(a => a.AuthorId == authorBookCounts.AuthorId);

                if (topAuthor != null)
                {
                    Console.WriteLine($"Nombre: {topAuthor.Name}, Libros publicados: {authorBookCounts.BookCount}");
                }
                else
                {
                    Console.WriteLine("No se encontró el autor.");
                }
            }
            else
            {
                Console.WriteLine("No hay libros registrados.");
            }


            // Mostrar en consola el autor y la cantidad de libros publicados.


            // Contar libros por autor y unir con información de autor
            var authorBookCounts2 = from book in allBooks
                                   group book by book.AuthorId into bookGroup
                                   join author in allAuthors on bookGroup.Key equals author.AuthorId
                                   select new
                                   {
                                       AuthorName = author.Name,
                                       BooksPublished = bookGroup.Count()
                                   };

            // Ordenar (opcional) y mostrar el resultado
            foreach (var item in authorBookCounts2.OrderBy(a => a.AuthorName))
            {
                Console.WriteLine($"Autor: {item.AuthorName}, Libros Publicados: {item.BooksPublished}");
            }


            // Mostrar en consola los libros publicados hace menos de 50 años.

            int currentYear = DateTime.Now.Year;
            int yearLimit = currentYear - 50;

            // Filtrar libros publicados en los últimos 50 años
            var librosMenos50Años = allBooks.Where(l => l.PublicationDate > yearLimit && l.PublicationDate <= currentYear).ToList();

            foreach (var item in librosMenos50Años)
            {
                Console.WriteLine($"Libro: {item.Title}, Fecha: {item.PublicationDate}");
            }




            // Mostrar en consola el libro más viejo.

            // Ordenar los libros por fecha de publicación y tomar el más antiguo
            var libroMasViejo = allBooks.OrderBy(book => book.PublicationDate).FirstOrDefault();

            if (libroMasViejo != null)
            {
                Console.WriteLine($"Libro más antiguo: {libroMasViejo.Title}, Fecha de publicación: {libroMasViejo.PublicationDate}");
            }
            else
            {
                Console.WriteLine("No hay libros disponibles.");
            }

            // Mostrar en consola los autores que tengan un libro que comience con "El".

            // Filtrar libros cuyos títulos comiencen con "El"
            var librosConEl = allBooks.Where(book => book.Title.StartsWith("El"));

            // Extraer los IDs de los autores de esos libros
            var authorIds = librosConEl.Select(book => book.AuthorId).Distinct();

            // Encontrar los autores correspondientes
            var authors = allAuthors.Where(author => authorIds.Contains(author.AuthorId));

            // Mostrar en consola
            foreach (var author in authors)
            {
                Console.WriteLine($"Autor: {author.Name}");
            }
        }
    }
}

