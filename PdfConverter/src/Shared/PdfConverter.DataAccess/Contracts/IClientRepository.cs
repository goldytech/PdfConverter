namespace Contoso.PdfConverter.DataAccess.Contracts
{
    using System.Threading.Tasks;

    using Contoso.PdfConverter.DomainModel;

    /// <summary>
    /// The ClientRepository interface.
    /// </summary>
    public interface IClientRepository : IDataRepository<Client, long>
    {
        /// <summary>
        /// Checks whether email exists or not
        /// </summary>
        /// <param name="email">
        ///     The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        Task<bool> IsEmailUnique(string email);
    }
}
