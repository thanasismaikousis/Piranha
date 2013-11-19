-- Default users
INSERT INTO sysuser (sysuser_id, sysuser_apikey, sysuser_login, sysuser_group_id, sysuser_created, sysuser_updated)
VALUES ('ca19d4e7-92f0-42f6-926a-68413bbdafbc', 'FE868D4F-797C-4E60-B876-64E6FC2424AA', 'sys', '7c536b66-d292-4369-8f37-948b32229b83',
	GETDATE(), GETDATE());

-- Default groups
INSERT INTO sysgroup (sysgroup_id, sysgroup_parent_id, sysgroup_name, sysgroup_description, sysgroup_created, sysgroup_updated)
VALUES ('7c536b66-d292-4369-8f37-948b32229b83', NULL, 'Systemadministrator', 
	'System administrator group with full permissions.', GETDATE(), GETDATE());
INSERT INTO sysgroup (sysgroup_id, sysgroup_parent_id, sysgroup_name, sysgroup_description, sysgroup_created, sysgroup_updated)
VALUES ('8940b41a-e3a9-44f3-b564-bfd281416141', '7c536b66-d292-4369-8f37-948b32229b83', 'Administrator', 
	'Web site administrator group.', GETDATE(), GETDATE());

-- Default params
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('9a14664f-806d-4a4f-9a72-e8368fb358d5', 'SITE_VERSION', '32', 'The currently installed version of Piranha.', 1, 
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('CF06BF4C-C426-4047-8E5E-6E0082AAF1BF', 'SITE_LAST_MODIFIED', GETDATE(), 'Global last modification date.', 1, 
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('C08B1891-ABA2-4E0D-AD61-2ABDFBA81A59', 'CACHE_PUBLIC_EXPIRES', 0, 'How many minutes browsers are allowed to cache public content.', 1, 
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('48BDF688-BA95-46B4-91C7-6A8430F387FF', 'CACHE_PUBLIC_MAXAGE', 0, 'How many minutes cached content is valid in the browser.', 1, 
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('08E8A582-7825-43B2-A12D-2522889F04BE', 'IMAGE_MAX_WIDTH', 940, 'Maximum width for uploaded images.', 1, 
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('095502DD-D655-4001-86F9-97D18222A548', 'SITEMAP_EXPANDED_LEVELS', '0', 'The number of pre-expanded levels in the manager panel for the page list.', 1, 
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('40230360-71CE-441E-A8DF-D50CFA79ACC2', 'RSS_NUM_POSTS', 10, 'The maximum number posts to be exported in a feed. For an infinite amount of posts, use the value 0.', 1,
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('A64A8479-8125-47BA-9980-B30B36E744D3', 'RSS_USE_EXCERPT', '1', 'Weather to use an excerpt in the feeds or export the full content.', 1,
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('5A0D6307-F041-41A1-B63A-563E712F3B8C', 'HIERARCHICAL_PERMALINKS', '0', 'Weather or not permalink generation should be hierarchical.', 1,
	GETDATE(), GETDATE());
INSERT INTO sysparam (sysparam_id, sysparam_name, sysparam_value, sysparam_description, sysparam_locked, sysparam_created, sysparam_updated)
VALUES ('4C694949-DEE0-465E-AB08-253927BDCBD8', 'SITE_PRIVATE_KEY', SUBSTRING(REPLACE(CAST(NEWID() AS NVARCHAR(38)), '-', ''), 1, 16), 
	'The private key used for public key encryption.', 1, GETDATE(), GETDATE());

-- Default templates
INSERT INTO pagetemplate (pagetemplate_id, pagetemplate_name, pagetemplate_description, pagetemplate_preview, pagetemplate_created, pagetemplate_updated)
VALUES ('906761ea-6c04-4f4b-9365-f2c350ff4372', 'Standard page', 'Standard page type.',
	'<table class="template"><tr><td id="Content"></td></tr></table>', GETDATE(), GETDATE());
INSERT INTO posttemplate (posttemplate_id, posttemplate_name, posttemplate_description, posttemplate_preview, posttemplate_created, posttemplate_updated)
VALUES ('5017dbe4-5685-4941-921b-ca922edc7a12', 'Standard post', 'Standard post type.', 
	'<table class="template"><tr><td></td></tr></table>', GETDATE(), GETDATE());
INSERT INTO regiontemplate (regiontemplate_id, regiontemplate_template_id, regiontemplate_internal_id, regiontemplate_seqno,
	regiontemplate_name, regiontemplate_type, regiontemplate_created, regiontemplate_updated)
VALUES ('96ADAC79-5DC5-453D-A0DE-A6871D74FD99', '906761ea-6c04-4f4b-9365-f2c350ff4372', 'Content', 1, 
	'Content', 'Piranha.Extend.Regions.HtmlRegion', GETDATE(), GETDATE());

-- Default namespaces
INSERT INTO [namespace] ([namespace_id], [namespace_internal_id], [namespace_name], [namespace_description], [namespace_created], [namespace_updated])
	VALUES ('8FF4A4B4-9B6C-4176-AAA2-DB031D75AC03', 'DEFAULT', 'Default namespace', 'This is the default namespace for all pages and posts.',
		GETDATE(), GETDATE());
INSERT INTO [namespace] ([namespace_id], [namespace_internal_id], [namespace_name], [namespace_description], [namespace_created], [namespace_updated])
	VALUES ('AE46C4C4-20F7-4582-888D-DFC148FE9067', 'CATEGORY', 'Category namespace', 'This is the namespace for all categories.',
		GETDATE(), GETDATE());
INSERT INTO [namespace] ([namespace_id], [namespace_internal_id], [namespace_name], [namespace_description], [namespace_created], [namespace_updated])
	VALUES ('C8342FB4-D38E-4EAF-BBC1-4EF3BDD7500C', 'ARCHIVE', 'Archive namespace', 'This is the archive namespace for all post types.',
		GETDATE(), GETDATE());
INSERT INTO [namespace] ([namespace_id], [namespace_internal_id], [namespace_name], [namespace_description], [namespace_created], [namespace_updated])
	VALUES ('368249B1-7F9C-4974-B9E3-A55D068DD9B6', 'MEDIA', 'Media namespace', 'This is the media namespace for all images & documents.',
		GETDATE(), GETDATE());

-- Default site tree
INSERT INTO [sitetree] ([sitetree_id], [sitetree_namespace_id], [sitetree_internal_id], [sitetree_name], [sitetree_description], [sitetree_meta_title],
	[sitetree_meta_description], [sitetree_created], [sitetree_updated])
VALUES ('C2F87B2B-F585-4696-8A2B-3C9DF882701E', '8FF4A4B4-9B6C-4176-AAA2-DB031D75AC03', 'DEFAULT_SITE', 'Default site', 'This is the default site tree.',
	'My site', 'Welcome the the template site', GETDATE(), GETDATE());

-- Add site template and page for the default site
INSERT INTO pagetemplate (pagetemplate_id, pagetemplate_name, pagetemplate_site_template, pagetemplate_created, pagetemplate_updated)
VALUES ('C2F87B2B-F585-4696-8A2B-3C9DF882701E', 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', 1,
	 GETDATE(), GETDATE());
INSERT INTO permalink (permalink_id, permalink_namespace_id, permalink_type, permalink_name, permalink_created, permalink_updated)
VALUES ('2E168001-D113-4216-ACC5-03C61C2D0C21', '8FF4A4B4-9B6C-4176-AAA2-DB031D75AC03', 'SITE', 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', 
	GETDATE(), GETDATE());
INSERT INTO page (page_id, page_sitetree_id, page_draft, page_template_id, page_permalink_id, page_parent_id, page_seqno, page_title, 
	page_created, page_updated, page_published, page_last_published)
VALUES ('94823A5C-1E29-4BDB-84E4-9B5F636CDDB5', 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', 1, 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', '2E168001-D113-4216-ACC5-03C61C2D0C21', 
	'C2F87B2B-F585-4696-8A2B-3C9DF882701E', 1, 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', GETDATE(), GETDATE(), GETDATE(), GETDATE());
INSERT INTO page (page_id, page_sitetree_id, page_draft, page_template_id, page_permalink_id, page_parent_id, page_seqno, page_title, 
	page_created, page_updated, page_published, page_last_published)
VALUES ('94823A5C-1E29-4BDB-84E4-9B5F636CDDB5', 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', 0, 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', '2E168001-D113-4216-ACC5-03C61C2D0C21', 
	'C2F87B2B-F585-4696-8A2B-3C9DF882701E', 1, 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', GETDATE(), GETDATE(), GETDATE(), GETDATE());

-- Permalink
INSERT INTO permalink (permalink_id, permalink_namespace_id, permalink_type, permalink_name, permalink_created, permalink_updated)
VALUES ('1e64c1d4-e24f-4c7c-8f61-f3a75ad2e2fe', '8FF4A4B4-9B6C-4176-AAA2-DB031D75AC03', 'PAGE', 'start', GETDATE(), GETDATE());

-- Default page
INSERT INTO page (page_id, page_sitetree_id, page_draft, page_template_id, page_permalink_id, page_seqno, page_title, page_keywords, page_description,
	page_created, page_updated, page_published, page_last_published, page_last_modified)
VALUES ('7849b6d6-dc43-43f6-8b5a-5770ab89fbcf', 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', 1, '906761ea-6c04-4f4b-9365-f2c350ff4372', '1e64c1d4-e24f-4c7c-8f61-f3a75ad2e2fe', 
	1, 'Start', 'Piranha, Welcome', 'Welcome to Piranha', GETDATE(), GETDATE(), GETDATE(), GETDATE(), GETDATE());
INSERT INTO page (page_id, page_sitetree_id, page_draft, page_template_id, page_permalink_id, page_seqno, page_title, page_keywords, page_description,
	page_created, page_updated, page_published, page_last_published, page_last_modified)
VALUES ('7849b6d6-dc43-43f6-8b5a-5770ab89fbcf', 'C2F87B2B-F585-4696-8A2B-3C9DF882701E', 0, '906761ea-6c04-4f4b-9365-f2c350ff4372', '1e64c1d4-e24f-4c7c-8f61-f3a75ad2e2fe', 
	1, 'Start', 'Piranha, Welcome', 'Welcome to Piranha', GETDATE(), GETDATE(), GETDATE(), GETDATE(), GETDATE());

-- Region
INSERT INTO region (region_id, region_draft, region_page_id, region_page_draft, region_regiontemplate_id,
	region_body, region_created, region_updated)
VALUES ('87ec4dbd-c3ba-4a6b-af49-78421528c363', 1, '7849b6d6-dc43-43f6-8b5a-5770ab89fbcf', 1, '96ADAC79-5DC5-453D-A0DE-A6871D74FD99',
	'<p>Welcome to Piranha -  the fun, fast and lightweight framework for developing cms-based web applications with an extra bite.</p>', GETDATE(), GETDATE());
INSERT INTO region (region_id, region_draft, region_page_id, region_page_draft, region_regiontemplate_id, 
	region_body, region_created, region_updated)
VALUES ('87ec4dbd-c3ba-4a6b-af49-78421528c363', 0, '7849b6d6-dc43-43f6-8b5a-5770ab89fbcf', 0, '96ADAC79-5DC5-453D-A0DE-A6871D74FD99',
	'<p>Welcome to Piranha -  the fun, fast and lightweight framework for developing cms-based web applications with an extra bite.</p>', GETDATE(), GETDATE());
