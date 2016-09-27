GO

CREATE TABLE [EDNF_Account_RolePermissionsAction](
	[ARPAID] uniqueidentifier NOT NULL,
	[ARPID] uniqueidentifier NOT NULL,
	[ActionCode] [varchar](100) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_EDNF_Account_RolePermissionsAction] PRIMARY KEY CLUSTERED 
(
	[ARPAID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'b648adc4-fce8-4e24-b1f6-00ca91bfd655', N'b06ba008-ab7e-4b7a-a36a-235c728aa220', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'ed1ff86d-e2db-4804-b12b-05e79d06cc1b', N'de1cc83d-63b6-4959-989c-1a106c5152d3', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'fca52c32-2692-4f41-926b-11a964efb79b', N'5f33e3de-3df2-448c-a012-e35c9192ed18', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'500b428a-315a-46bb-9f08-11ab7a8031a8', N'96e46be4-dda2-4f6d-b4cf-aaacdbcfd3fa', N'btn_clear', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'10c957da-44b0-413e-9e4b-17e4d7f29922', N'aceb8525-4c58-4cc8-932e-4951c430a77e', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'742d2a95-8c05-4042-86d8-17eb8a4115d0', N'de1cc83d-63b6-4959-989c-1a106c5152d3', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'efd0aab3-3c13-4e65-9d65-1e395d8a51bd', N'bc02d730-b384-4ea0-8ca1-374847a66bfc', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'95d6a2d2-90f7-4cfe-9385-249a9c27a506', N'5f33e3de-3df2-448c-a012-e35c9192ed18', N'btn_search', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'64b88016-5453-4e55-977a-2aaf11887854', N'8665d89b-9ad7-4e4f-91ee-53dc12079adf', N'btn_file_manager', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'0f299d26-a567-40b1-b2d3-2bc2be3fb114', N'0205cedc-257e-4534-b75a-1c8c0c99be85', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'ae08239e-e8b2-473f-ba98-2c29697bf0dd', N'368a35c0-b35c-43b1-9011-1911efb0085a', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'1c690226-bc4e-4a71-a360-32f9fbe15c79', N'aceb8525-4c58-4cc8-932e-4951c430a77e', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'7a6fc846-cdf3-4e93-abfb-37278c14a5bc', N'de1cc83d-63b6-4959-989c-1a106c5152d3', N'btn_clear', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'fa915f07-168a-472b-b5e6-37a716246562', N'aceb8525-4c58-4cc8-932e-4951c430a77e', N'btn_search', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'3bfcb643-4e4a-4199-b896-3f9e167b8137', N'40dcb828-3b6d-4630-95a5-5530e77c1047', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'8dd33ab5-0634-4709-b8ff-46d29fc242a9', N'5f33e3de-3df2-448c-a012-e35c9192ed18', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'33bf5624-2bf5-4305-a7b0-5196aceb67ad', N'034db0df-a4fb-4b7c-b9fa-821adaf3d2ce', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'cbd91c02-821b-4c45-9673-524d4ceb3709', N'8665d89b-9ad7-4e4f-91ee-53dc12079adf', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'07603591-7f16-4f31-b895-52fe77b0c077', N'006737dc-38ac-48b9-b190-53a043e59d9f', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'7c77faa6-1f63-4522-9a98-5332b348b1d7', N'a43107d5-8d3d-481f-abd9-5b48b20e1f86', N'btn_save', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'bc6011fe-c32e-4804-828b-5401858629b6', N'006737dc-38ac-48b9-b190-53a043e59d9f', N'btn_clear', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'0ec29bc3-171d-470f-b8b1-5bf99de42977', N'e3cd9586-fcb4-4a79-8318-a41224873230', N'btn_action_load', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'1ce5441a-c102-427b-917c-64658cc7978e', N'bc02d730-b384-4ea0-8ca1-374847a66bfc', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'c2c91a58-95ff-4c44-8348-64d5eae576e2', N'368a35c0-b35c-43b1-9011-1911efb0085a', N'btn_search', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'87b26174-1cd2-4d51-8cc6-65e63e4f0f44', N'6bbaf880-833b-4c22-b33c-fc9a717f60e2', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'8075f813-175f-41b7-9198-691139080178', N'bc02d730-b384-4ea0-8ca1-374847a66bfc', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'3f7e1d2b-90d1-4cc0-b94a-738c12bf2b16', N'006737dc-38ac-48b9-b190-53a043e59d9f', N'btn_save', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'114a1ecd-5997-4bf7-8a51-76242e7c787d', N'40dcb828-3b6d-4630-95a5-5530e77c1047', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'f27292de-627a-433b-9cfc-79fc4f0a498f', N'b06ba008-ab7e-4b7a-a36a-235c728aa220', N'btn_search', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'c0d4d04f-b8c1-4061-a9e5-7a8847ed4ade', N'368a35c0-b35c-43b1-9011-1911efb0085a', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'107e0312-2f15-4cb3-a3d9-7b57026fbd86', N'7627bede-bee4-4d26-8678-6ca577f34bd2', N'btn_save', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'9227a3dc-d9e8-48ff-bb4c-7cb53aec935b', N'40dcb828-3b6d-4630-95a5-5530e77c1047', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'a2e516ff-da19-4566-b84c-7f9913541b5f', N'006737dc-38ac-48b9-b190-53a043e59d9f', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'13627608-d0f9-4c96-98b6-8786ef9b52a0', N'0205cedc-257e-4534-b75a-1c8c0c99be85', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'd9a7705b-4e48-45e0-8f5b-8ad035b62445', N'6bbaf880-833b-4c22-b33c-fc9a717f60e2', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'c0ab13fd-f09e-48d6-88cb-953d30b2b45c', N'006737dc-38ac-48b9-b190-53a043e59d9f', N'btn_action_manager', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'd0309675-9c03-4db4-8597-9ceb5cbb00eb', N'0205cedc-257e-4534-b75a-1c8c0c99be85', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'6a3f5881-0022-4ea4-991f-afb4aeb89cc4', N'034db0df-a4fb-4b7c-b9fa-821adaf3d2ce', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'65f79684-2edc-4da6-98a1-afd476b6d68b', N'5f33e3de-3df2-448c-a012-e35c9192ed18', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'd4b1ca34-1bbd-4232-96bf-ba64dba66010', N'aceb8525-4c58-4cc8-932e-4951c430a77e', N'btn_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'05774890-6c75-47e9-b862-c15c76e794ec', N'96e46be4-dda2-4f6d-b4cf-aaacdbcfd3fa', N'btn_viewdetail', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'6272ed65-1ef0-4442-b9d8-cc888698cee5', N'006737dc-38ac-48b9-b190-53a043e59d9f', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'6146a46f-dfa2-41df-b467-d237d4259366', N'e3cd9586-fcb4-4a79-8318-a41224873230', N'btn_promission_gave', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'2b79aa58-5e59-493d-af54-d88c96fd82c1', N'b06ba008-ab7e-4b7a-a36a-235c728aa220', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'824cd162-b567-4ed5-9a83-db054c97d2d3', N'b06ba008-ab7e-4b7a-a36a-235c728aa220', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'351262e4-dc3a-4f7d-8a36-df4cfcf23732', N'6bbaf880-833b-4c22-b33c-fc9a717f60e2', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'f76ef1b4-8a77-481c-ab4b-ea296020b094', N'c8ecc8c0-1a8e-4504-ab99-809f1db2be4a', N'btn_save', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'8b4a7900-0280-4467-ad64-eec4cf622809', N'034db0df-a4fb-4b7c-b9fa-821adaf3d2ce', N'btn_delete', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'dc18d5c8-b5b9-4f7d-8e19-ef0df39240f5', N'e3cd9586-fcb4-4a79-8318-a41224873230', N'btn_user_remove', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'0722ea95-99d9-44dd-ad55-f03b877a2e2b', N'368a35c0-b35c-43b1-9011-1911efb0085a', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'40abfee5-4db1-4b6c-9b1a-f1bc12a77b54', N'8665d89b-9ad7-4e4f-91ee-53dc12079adf', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'b74466ed-21c9-40b3-b710-f509ef7ccac6', N'de1cc83d-63b6-4959-989c-1a106c5152d3', N'btn_modify', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'1bfb367d-5a42-4b89-adad-f7686922a034', N'e3cd9586-fcb4-4a79-8318-a41224873230', N'btn_action_save', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'acdc55db-ac73-437e-b9b2-ff8d1684e81f', N'e3cd9586-fcb4-4a79-8318-a41224873230', N'btn_user_add', 1)
INSERT [EDNF_Account_RolePermissionsAction] ([ARPAID], [ARPID], [ActionCode], [RoleID]) VALUES (N'6f12e5a1-a6c1-4d90-9b5e-2df7d68b66b5', N'b06ba008-ab7e-4b7a-a36a-235c728aa220', N'btn_recycle', 1)

GO