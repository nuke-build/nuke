import React from 'react';
import ExecutionEnvironment from "@docusaurus/core/lib/client/exports/ExecutionEnvironment";

function Root({children}) {
    if (ExecutionEnvironment.canUseDOM) {
        const parts = window.location.href.split("?");
        if (parts.length > 1) {
            setTimeout(() => window.history.replaceState({}, document.title, parts[0]), 4000);
        }
    }

    return <>{children}</>;
}

export default Root;
