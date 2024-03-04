'use client'; // This is a client component 👈🏽

import React, { useEffect, useState } from 'react';
import SearchBar from '@/components/issues/searchBar';
import NewIssueButton from '@/components/issues/newIssueButton';
import IssueCard from '@/components/issues/issueCard';
// NewIssueButton component

// IssueCard component

// Main Issue component
const Issue = () => {
  // Dummy data (replace with actual data from backend)
  const [issues, setIssues] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Fetch issues from the backend API
  useEffect(() => {
    // Dummy repositoryId, replace with the actual repositoryId
    const repositoryId = 1;

    // Fetch issues from the backend API
    fetch(`http://localhost:5169/api/Issue/issues/${repositoryId}`)
      .then((response) => response.json())
      .then((data) => {
        const mappedIssues = data.map((backendIssue) => {
          const createdDate = new Date(backendIssue.createdDate);
          const currentDate = new Date();
          const timeDifferenceInMs = currentDate - createdDate;

          let timeElapsed;
          if (timeDifferenceInMs < 3600000) {
            // Less than an hour
            timeElapsed =
              Math.floor(timeDifferenceInMs / 60000) + ' minutes ago';
          } else if (timeDifferenceInMs < 86400000) {
            // Less than a day
            timeElapsed =
              Math.floor(timeDifferenceInMs / 3600000) + ' hours ago';
          } else {
            // More than a day
            timeElapsed =
              Math.floor(timeDifferenceInMs / 86400000) + ' days ago';
          }

          return {
            id: backendIssue.id,
            title: backendIssue.title,
            description: backendIssue.description,
            username: backendIssue.creatorUsername,
            openedDate: timeElapsed,
            labels: backendIssue.labelNames,
          };
        });

        setIssues(mappedIssues);
        setLoading(false);
      })
      .catch((error) => {
        console.error('Error fetching issues:', error);
        setError('Error fetching issues. Please try again later.');
        setLoading(false);
      });
  }, []); // Empty dependency array ensures the effect runs only once on mount

  return (
    <div className="px-4 md:px-6 xl:px-8 py-6 space-y-6">
      <div className="space-y-1">
        <h1 className="text-2xl font-bold tracking-tight">Issues</h1>
      </div>
      <div className="space-y-4">
        {/* Search bar */}
        <SearchBar />
        <div className="grid gap-4">
          {/* New Issue button */}
          <NewIssueButton />
          {/* Issue cards */}

          {loading && <p>Loading...</p>}
          {error && <p>error</p>}
          {!loading &&
            !loading &&
            issues.map((issue, index) => <IssueCard key={index} {...issue} />)}
        </div>
      </div>
    </div>
  );
};

export default Issue;
