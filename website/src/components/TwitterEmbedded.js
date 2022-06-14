import React, { useEffect, useState } from 'react';
import { useColorMode } from '@docusaurus/theme-common';

/**
 * Embeds a twitter post
 *
 * @param conversation
 * @param {React.ReactNode} children - the blockquote of the tweet
 * click `Embed Twitter` on the tweet and it will be generated from here: https://publish.twitter.com/
 */
export const TwitterEmbedded = ({ conversation, children }) => {
    const { isDarkTheme } = useColorMode();

    useEffect(() => {
        let script = document.getElementById('twitter-wjs');

        if (!script) {
            script = document.createElement('script');

            script.src = "https://platform.twitter.com/widgets.js";
            script.async = true;
            script.charset = "utf-8";
            script.id = "twitter-wjs";

            document.body.appendChild(script);
        }

        return () => {
            if (script) {
                document.body.removeChild(script);
            }
        }
    }, []);


    return (
        <blockquote
            className="twitter-tweet"
            data-theme={isDarkTheme ? "dark" : "light"}
            data-conversation={conversation ? "all" : "none"}
            // data-align="center"
            // Remount the DOM when color changes
            // key={isDarkTheme}
            >
            {children}
        </blockquote>
    );
}
