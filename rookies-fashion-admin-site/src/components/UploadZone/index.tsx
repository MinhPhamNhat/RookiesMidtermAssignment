import React, { useState, useEffect } from "react";
import { useDropzone } from "react-dropzone";
import "./index.css";
const UploadZone: React.FC<any> = (props) => {
  const { onFileUploaded } = props;
  const { acceptedFiles, getRootProps, getInputProps } = useDropzone({
    maxFiles: 2,
    accept: "image/jpeg,image/png,image/webp",
  });
  useEffect(() => {
    onFileUploaded(acceptedFiles);
  }, [acceptedFiles]);
  const acceptedFileItems = acceptedFiles.map((file: any) => (
    <li key={file.path}>
      {file.path} - {file.size} bytes
    </li>
  ));

  return (
    <section className="upload-container">
      <div {...getRootProps({ className: "dropzone" })}>
        <input {...getInputProps()} />
        <p>Drag 'n' drop some files here, or click to select files</p>
        <em>(2 files are the maximum number of files you can drop here)</em>
      </div>

      <aside className="">{acceptedFileItems}</aside>
    </section>
  );
};
export default UploadZone;
