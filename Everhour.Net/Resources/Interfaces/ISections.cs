using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Everhour.Net.Models;

namespace Everhour.Net
{
    internal partial interface IEverhourClient
    {
        Task<ListProjectSectionsResponse> ListProjectSectionsAsync(string projectId);
        Task<CreateSectionResponse> CreateSectionAsync(CreateSectionRequest request);
        Task<CreateSectionResponse> CreateSectionAsync(string projectId, string name);
        Task<RetrieveSectionResponse> RetrieveSectionAsync(int sectionId);
        Task<UpdateSectionResponse> UpdateSectionAsync(UpdateSectionRequest request);
        Task<UpdateSectionResponse> UpdateSectionAsync(int sectionId, string name);
        Task<bool> DeleteSectionAsync(int sectionId);
    }
}