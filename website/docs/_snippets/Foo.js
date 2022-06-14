import React from "react";
import CodeBlock from '@theme/CodeBlock';

export default function HomepageFeatures() {
    return (
        <CodeBlock title="foo">
            {''}<span className="keyword">using</span> <span className="namespace-name">System</span>;{'\n'}
            {''}<span className="keyword">using</span> <span className="namespace-name">System</span><span className="operator">.</span><span className="namespace-name">Text</span><span className="operator">.</span><span className="namespace-name">RegularExpressions</span>;{'\n'}
            {''}{'\n'}
            {''}<span className="comment">// ReSharper disable All</span>{'\n'}
            {''}<span className="preprocessor-keyword">#</span><span className="preprocessor-keyword">pragma</span> <span className="preprocessor-keyword">warning</span> <span className="preprocessor-keyword">disable</span> <span className="number">67</span>{'\n'}
            {''}<span className="preprocessor-keyword">#</span><span className="preprocessor-keyword">pragma</span> <span className="preprocessor-keyword">warning</span> <span className="preprocessor-keyword">disable</span> <span className="number">169</span>{'\n'}
            {''}{'\n'}
            {''}<span className="keyword">class</span> <span className="class-name">All</span>{'\n'}
            {''}&#123;{'\n'}
            {''}    <span className="xml-doc-comment-delimiter">/**</span>{'\n'}
            {''}    <span className="xml-doc-comment-delimiter">*</span><span className="xml-doc-comment-text"> let's C# how it used to be</span>{'\n'}
            {''}    <span className="xml-doc-comment-delimiter">*/</span>{'\n'}
            {''}    <span className="keyword">public</span> <span className="keyword">delegate</span> <span className="keyword">void</span> <span className="delegate-name">EventHandler</span>(<span className="keyword">object</span> <span className="parameter-name">sender</span>, <span className="class-name">EventArgs</span> <span className="parameter-name">s</span>);{'\n'}
            {''}    <span className="keyword">public</span> <span className="keyword">event</span> <span className="delegate-name">EventHandler</span> <span className="event-name">Event</span>;{'\n'}
            {''}{'\n'}
        </CodeBlock>
    );
}
