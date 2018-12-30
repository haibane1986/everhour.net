using System;
using System.Net.Http;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    public partial class EverhourClient
    {
        private const string SECTIONS_PATH = "sections";

        /// <summary>
        /// Sections / List Project Sections
        /// </summary>
        /// <param name="projectId">Project ID</param>
        public async Task<ListProjectSectionsResponse> ListProjectSectionsAsync(string projectId)
        {
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null or empty.", nameof(projectId));

            return await ExecuteAsync<ListProjectSectionsResponse>(Request(PROJECTS_PATH, projectId, SECTIONS_PATH, HttpMethod.Get)).ConfigureAwait(false);
        }

        /// <summary>
        /// Sections / Create Section
        /// </summary>
        public async Task<CreateSectionResponse> CreateSectionAsync(CreateSectionRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Name));
            if (request.Status == null) throw new ArgumentNullException("Value cannot be null.", nameof(request.Status));
            if (request.Position <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(request.Position));

            return await ExecuteAsync<CreateSectionResponse>(CreateRequest<CreateSectionRequest>(PROJECTS_PATH, request.ProjectId, SECTIONS_PATH, request)).ConfigureAwait(false);
        }


        /// <summary>
        /// Sections / Create Section
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="name">Section Name</param>
        public async Task<CreateSectionResponse> CreateSectionAsync(string projectId, string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));
            if (string.IsNullOrEmpty(projectId)) throw new ArgumentException("Value cannot be null or empty.", nameof(projectId));

            return await ExecuteAsync<CreateSectionResponse>(CreateRequest<CreateSectionRequest>(PROJECTS_PATH, projectId, SECTIONS_PATH, new CreateSectionRequest() { ProjectId = projectId, Name = name })).ConfigureAwait(false);
        }

        /// <summary>
        /// Sections / Retrieve Section
        /// </summary>
        /// <param name="sectionId">Section ID</param>
        public async Task<RetrieveSectionResponse> RetrieveSectionAsync(int sectionId) 
        {
            if (sectionId <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(sectionId));

            return await ExecuteAsync<RetrieveSectionResponse>(Request(SECTIONS_PATH, sectionId, HttpMethod.Get)).ConfigureAwait(false);
        }
        
                /// <summary>
        /// Sections / Update Section
        /// </summary>
        public async Task<UpdateSectionResponse> UpdateSectionAsync(UpdateSectionRequest request)
        {
            if (request == null) throw new ArgumentNullException("Value cannot be null.", nameof(request));
            if (request.Id <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(request.Id));
            if (string.IsNullOrEmpty(request.Name)) throw new ArgumentException("Value cannot be null or empty.", nameof(request.Name));
            if (request.Position <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(request.Position));
            if (request.Status == null) throw new ArgumentNullException("Value cannot be null.", nameof(request.Status));

            return await ExecuteAsync<UpdateSectionResponse>(UpdateRequest<UpdateSectionRequest>(SECTIONS_PATH, request.Id, request)).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Sections / Update Section
        /// </summary>
        /// <param name="sectionId">Section ID</param>
        /// <param name="name">Section Name</param>
        public async Task<UpdateSectionResponse> UpdateSectionAsync(int sectionId, string name)
        {
            if (sectionId <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(sectionId));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            return await ExecuteAsync<UpdateSectionResponse>(UpdateRequest<UpdateSectionRequest>(SECTIONS_PATH, sectionId, new UpdateSectionRequest() { Name = name })).ConfigureAwait(false);
        }
        
        /// <summary>
        /// Sections / Delete Section
        /// </summary>
        /// <param name="sectionId">Section ID</param>
        public async Task<bool> DeleteSectionAsync(int sectionId)
        {
            if (sectionId <= 0) throw new ArgumentOutOfRangeException("Value must be positive and non zero.", nameof(sectionId));

            var result = await ExecuteAsync(Request(SECTIONS_PATH, sectionId, HttpMethod.Delete)).ConfigureAwait(false);

            return result.IsSuccessfulDelete();
        }
    }
}