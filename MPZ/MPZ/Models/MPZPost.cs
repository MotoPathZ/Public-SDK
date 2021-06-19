using System;
using System.Collections.Generic;
using System.Text;

namespace MPZ.Models
{
    public class MPZPost : Services.Communication.PostController
    {
        public uint id { get; set; }
        public string uuid { get; set; }
        public string author_uuid { get; set; }
        public string attachments_uuids { get; set; }
        public string body { get; set; }
        public string view_count { get; set; }
        public string verification_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public MPZUser author { get; set; }
        public List<MPZAttachment> attachments { get; set; }

        public MPZPost(string _uuid)
        {
            _ = InitAsync(_uuid);
        }
        public MPZPost()
        {
            //For create MPZ Post and null var...
        }
        private async System.Threading.Tasks.Task InitAsync(string uuid)
        {
            MPZPost post = await ShowAsync(uuid);
            this.id = post.id;
            this.uuid = post.uuid;
            this.author_uuid = post.author_uuid;
            this.attachments_uuids = post.attachments_uuids;
            this.body = post.body;
            this.view_count = post.view_count;
            this.verification_at = post.verification_at;
            this.created_at = post.created_at;
            this.updated_at = post.updated_at;
            this.author = post.author;
        }
        public async System.Threading.Tasks.Task UpdateAsync(MPZPost updateData)
        {
            MPZPost post = await UpdateAsync(uuid, updateData);
            this.id = post.id;
            this.uuid = post.uuid;
            this.author_uuid = post.author_uuid;
            this.attachments_uuids = post.attachments_uuids;
            this.body = post.body;
            this.view_count = post.view_count;
            this.verification_at = post.verification_at;
            this.created_at = post.created_at;
            this.updated_at = post.updated_at;
            this.author = post.author;
        }
        public async System.Threading.Tasks.Task Delete()
        {
            MPZPost post = await DeleteAsync(uuid);
            this.id = post.id;
            this.uuid = post.uuid;
            this.author_uuid = post.author_uuid;
            this.attachments_uuids = post.attachments_uuids;
            this.body = post.body;
            this.view_count = post.view_count;
            this.verification_at = post.verification_at;
            this.created_at = post.created_at;
            this.updated_at = post.updated_at;
            this.author = post.author;
        }
    }
}
