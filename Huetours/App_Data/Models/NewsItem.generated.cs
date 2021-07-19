//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v8.15.0
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace Umbraco.Web.PublishedModels
{
	/// <summary>News Item</summary>
	[PublishedModel("newsItem")]
	public partial class NewsItem : PublishedContentModel, IContentBase
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		public new const string ModelTypeAlias = "newsItem";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<NewsItem, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public NewsItem(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Pin
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("pin")]
		public virtual bool Pin => this.Value<bool>("pin");

		///<summary>
		/// Published Date
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("publishedDate")]
		public virtual global::System.DateTime PublishedDate => this.Value<global::System.DateTime>("publishedDate");

		///<summary>
		/// Short Content
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("shortContent")]
		public virtual global::System.Web.IHtmlString ShortContent => this.Value<global::System.Web.IHtmlString>("shortContent");

		///<summary>
		/// Thumbnail Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("thumbnailImage")]
		public virtual global::Umbraco.Core.Models.MediaWithCrops ThumbnailImage => this.Value<global::Umbraco.Core.Models.MediaWithCrops>("thumbnailImage");

		///<summary>
		/// Content
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("content")]
		public virtual global::System.Web.IHtmlString Content => global::Umbraco.Web.PublishedModels.ContentBase.GetContent(this);

		///<summary>
		/// Page Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("pageTitle")]
		public virtual string PageTitle => global::Umbraco.Web.PublishedModels.ContentBase.GetPageTitle(this);

		///<summary>
		/// Sub Page Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "8.15.0")]
		[ImplementPropertyType("subPageTitle")]
		public virtual string SubPageTitle => global::Umbraco.Web.PublishedModels.ContentBase.GetSubPageTitle(this);
	}
}