# FindeX

FindeX is a scalable file and content search system designed to provide fast search across files without requiring direct file-system access during each search request.

The system is designed around two main concerns:

1. **Searching**
2. **Indexing**

## Search Goals

* Provide fast search across large collections of files.
* Support different clients such as Web, Mobile, Desktop, CLI, and other applications.
* Support searching by full or partial file name.
* Support searching by file type or extension.
* Support different matching strategies such as:

  * Exact
  * Contains
  * StartsWith
  * EndsWith
* Support case-sensitive and case-insensitive search.
* Support searching across one or multiple drives.
* Support searching across multiple machines.
* Support searching resources belonging to other users when the requester has the required permissions.
* Support searching file metadata.
* Support content-based search inside supported file formats.
* Support full-text document search.
* Support image search and image-content search.
* Support video metadata and content search.
* Support additional searchable content types over time.
* Aggregate search results from multiple machines, nodes, or data sources.
* Provide search statistics and performance measurements.
* Support scalable search as the number of files, users, machines, and concurrent requests increases.

## Indexing Goals

* Avoid direct file-system traversal for every search request.
* Collect searchable file information into a dedicated index layer.
* Support in-memory indexing.
* Support persistent indexing.
* Support different indexing structures depending on the type of search.
* Index file names, extensions, paths, metadata, and other searchable properties.
* Support indexing file content.
* Support indexing image-related information.
* Support indexing video-related information and metadata.
* Keep the index synchronized when files are:

  * Created
  * Updated
  * Renamed
  * Moved
  * Deleted
* Support indexing data from multiple machines and storage locations.
* Support distributed indexing across multiple nodes.
* Support partitioning and sharding of large indexes.
* Support index replication and synchronization.
* Allow indexing implementations and storage technologies to evolve independently from the search interface.
* Maintain enough information in the index to enforce access control and authorization during search.
* Scale the indexing process as the amount of data grows.

## Access Control Goals

* Allow each machine or client to define which files and resources are exposed to the system.
* Allow each machine or client to specify what operations a user is permitted to perform on a file.
* Support different permission levels such as:

  * Search
  * Read
  * Download
  * Modify
  * Rename
  * Move
  * Delete
* Prevent users from accessing or modifying files they are not authorized to use.
* Support permissions that may differ between users, machines, clients, and resources.
* Keep authorization information available alongside indexed resources so that search results can be filtered before being returned to the user.
* Support future distributed permission and policy management across multiple machines and clients.
* Ensure that search visibility and file modification permissions are treated separately.
* Allow a file to be searchable by a user while still preventing that user from modifying the original file.
* Support permission changes without requiring the entire search system to be redesigned.

## Long-Term Vision

FindeX aims to evolve into a general-purpose distributed file and content discovery system.

Search requests should be handled through a dedicated search layer rather than directly traversing the original file system for every request.

```text
Clients
   │
   ▼
Search Service
   │
   ▼
Search / Index Layer
   │
   ├── File Names
   ├── File Metadata
   ├── File Content
   ├── Images
   ├── Videos
   ├── Permissions
   └── Other Searchable Data
```

Each machine or client remains responsible for defining which resources are exposed and what actions users are allowed to perform on those resources.

```text
Machine / Client
      │
      ├── Files & Content
      ├── Search Visibility
      └── Access Permissions
               │
               ▼
          Indexing Layer
               │
               ▼
         Searchable Index
```

Indexing can collect information from multiple machines or storage locations:

```text
Machine A ─┐
Machine B ─┼──► Indexing Layer ───► Searchable Index
Machine C ─┘
```

The long-term objective is to keep searching, indexing, and resource access fast, extensible, secure, and scalable regardless of where the original files are physically stored.
