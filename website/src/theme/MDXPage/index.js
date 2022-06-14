import React from 'react';
import clsx from 'clsx';
import Layout from '@theme/Layout';
import MDXContent from '@theme/MDXContent';
import TOC from '@theme/TOC';
import {
  PageMetadata,
  HtmlClassNameProvider,
  ThemeClassNames,
} from '@docusaurus/theme-common';
import styles from './styles.module.css';
export default function MDXPage(props) {
  const {content: MDXPageContent} = props;
  const {
    metadata: {title, description, frontMatter},
  } = MDXPageContent;
  const {wrapperClassName, hide_table_of_contents: hideTableOfContents} =
    frontMatter;
  return (
    <HtmlClassNameProvider
      className={clsx(
        wrapperClassName ?? ThemeClassNames.wrapper.mdxPages,
        ThemeClassNames.page.mdxPage,
      )}>
      <PageMetadata title={title} description={description} />
      <Layout>
        <main className="container container--fluid margin-vert--lg">
          <div className={clsx('row', styles.mdxPageWrapper)}>
            <div className={clsx('col', !hideTableOfContents && 'col--8')}>
              <article>
                <MDXContent>
                  <MDXPageContent />
                </MDXContent>
              </article>
            </div>
            {!hideTableOfContents && MDXPageContent.toc && (
              <div className="col col--2">
                <TOC
                  toc={MDXPageContent.toc}
                  minHeadingLevel={frontMatter.toc_min_heading_level}
                  maxHeadingLevel={frontMatter.toc_max_heading_level}
                />
              </div>
            )}
          </div>
        </main>
      </Layout>
    </HtmlClassNameProvider>
  );
}
